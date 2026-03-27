using System.Collections.Concurrent;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

string allowedDirectory = "/Users/danilo/Desktop/dotnet";
string allowedDirectoryFullPath = Path.GetFullPath(allowedDirectory);
string telegramToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
    ?? throw new Exception("Defina a variável TELEGRAM_BOT_TOKEN");
string claudeCliPath = Environment.GetEnvironmentVariable("CLAUDE_CLI_PATH") ?? "claude";
string claudePermissionMode = Environment.GetEnvironmentVariable("CLAUDE_PERMISSION_MODE") ?? "acceptEdits";
string? claudeModel = Environment.GetEnvironmentVariable("CLAUDE_MODEL");

var sessoesPorChat = new ConcurrentDictionary<long, Guid>();
var locksPorChat = new ConcurrentDictionary<long, SemaphoreSlim>();
var telegram = new TelegramBotClient(telegramToken);

var botInfo = await telegram.GetMe();
Console.WriteLine($"Bot iniciado: @{botInfo.Username}");
Console.WriteLine("Aguardando mensagens... (Ctrl+C para parar)\n");

static string TruncarTexto(string texto, int limite)
{
    if (string.IsNullOrWhiteSpace(texto) || texto.Length <= limite)
        return texto;

    return texto[..limite] + "\n...[conteúdo truncado]...";
}

static IEnumerable<string> QuebrarMensagem(string texto, int tamanhoMaximo)
{
    if (string.IsNullOrEmpty(texto))
    {
        yield return texto;
        yield break;
    }

    for (int i = 0; i < texto.Length; i += tamanhoMaximo)
    {
        int tamanho = Math.Min(tamanhoMaximo, texto.Length - i);
        yield return texto.Substring(i, tamanho);
    }
}

string ObterPromptSistema()
{
    return
        "Você é Claude e deve responder sempre em português brasileiro. " +
        $"Você está operando dentro do diretório permitido \"{allowedDirectoryFullPath}\". " +
        "Use as ferramentas locais do Claude Code para ler, editar, criar arquivos e executar comandos quando necessário. " +
        "Nunca tente acessar caminhos fora do diretório permitido. " +
        "Sempre execute a tarefa no computador quando o usuário pedir explicitamente para criar, alterar ou buildar algo. " +
        "Ao final, responda ao usuário com um resumo objetivo do que foi feito e do resultado.";
}

Guid ObterOuCriarSessao(long chatId)
{
    return sessoesPorChat.GetOrAdd(chatId, _ => Guid.NewGuid());
}

SemaphoreSlim ObterLockDoChat(long chatId)
{
    return locksPorChat.GetOrAdd(chatId, _ => new SemaphoreSlim(1, 1));
}

async Task<string> ExecutarClaudeLocal(long chatId, string promptUsuario, CancellationToken ct)
{
    var sessionId = ObterOuCriarSessao(chatId);

    var startInfo = new ProcessStartInfo
    {
        FileName = claudeCliPath,
        WorkingDirectory = allowedDirectoryFullPath,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true,
    };

    startInfo.ArgumentList.Add("-p");
    startInfo.ArgumentList.Add("--add-dir");
    startInfo.ArgumentList.Add(allowedDirectoryFullPath);
    startInfo.ArgumentList.Add("--permission-mode");
    startInfo.ArgumentList.Add(claudePermissionMode);
    startInfo.ArgumentList.Add("--session-id");
    startInfo.ArgumentList.Add(sessionId.ToString());
    startInfo.ArgumentList.Add("--append-system-prompt");
    startInfo.ArgumentList.Add(ObterPromptSistema());

    if (!string.IsNullOrWhiteSpace(claudeModel))
    {
        startInfo.ArgumentList.Add("--model");
        startInfo.ArgumentList.Add(claudeModel);
    }

    startInfo.ArgumentList.Add(promptUsuario);

    using var process = new Process { StartInfo = startInfo };

    process.Start();
    process.StandardInput.Close();

    var stdoutTask = process.StandardOutput.ReadToEndAsync(ct);
    var stderrTask = process.StandardError.ReadToEndAsync(ct);

    using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    timeoutCts.CancelAfter(TimeSpan.FromMinutes(5));

    try
    {
        await process.WaitForExitAsync(timeoutCts.Token);
    }
    catch (OperationCanceledException)
    {
        try
        {
            if (!process.HasExited)
                process.Kill(entireProcessTree: true);
        }
        catch
        {
        }

        if (ct.IsCancellationRequested)
            throw;

        throw new Exception("O Claude local demorou mais de 5 minutos para responder.");
    }

    string stdout = (await stdoutTask).Trim();
    string stderr = (await stderrTask).Trim();

    if (!string.IsNullOrWhiteSpace(stderr))
        Console.WriteLine($"[CLAUDE STDERR] {TruncarTexto(stderr, 500)}");

    if (process.ExitCode != 0)
    {
        string detalheErro = string.IsNullOrWhiteSpace(stderr) ? "Sem detalhes no stderr." : stderr;
        throw new Exception($"Falha ao executar o Claude local (exit code {process.ExitCode}). {TruncarTexto(detalheErro, 1500)}");
    }

    if (string.IsNullOrWhiteSpace(stdout))
        return "O Claude local concluiu a solicitação, mas não retornou texto.";

    return stdout;
}

async Task EnviarRespostaTelegram(ITelegramBotClient bot, long chatId, string texto, CancellationToken ct)
{
    foreach (var parte in QuebrarMensagem(texto, 3500))
    {
        await bot.SendMessage(chatId, parte, cancellationToken: ct);
    }
}

async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
{
    if (update.Message is not { Text: { } texto } msg) return;

    long chatId = msg.Chat.Id;
    string usuario = msg.From?.FirstName ?? "Usuário";

    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {usuario} ({chatId}): {texto}");

    if (texto.Trim().Equals("/limpar", StringComparison.OrdinalIgnoreCase))
    {
        sessoesPorChat.TryRemove(chatId, out _);
        await bot.SendMessage(chatId, "Sessão do Claude reiniciada. A próxima mensagem começará um novo contexto.", cancellationToken: ct);
        return;
    }

    if (texto.Trim().Equals("/start", StringComparison.OrdinalIgnoreCase))
    {
        await bot.SendMessage(
            chatId,
            "Olá! Sou a ponte entre o Telegram e o Claude local do seu computador.\n\n" +
            $"Vou executar as instruções usando o CLI `claude` dentro de `{allowedDirectoryFullPath}`.\n" +
            $"Modo de permissão atual: `{claudePermissionMode}`.\n" +
            "Use /limpar para reiniciar a sessão do chat.",
            cancellationToken: ct);
        return;
    }

    var chatLock = ObterLockDoChat(chatId);
    await chatLock.WaitAsync(ct);

    try
    {
        await bot.SendChatAction(chatId, ChatAction.Typing, cancellationToken: ct);

        string resposta = await ExecutarClaudeLocal(chatId, texto, ct);

        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Claude local → {usuario}: {TruncarTexto(resposta, 120)}");
        await EnviarRespostaTelegram(bot, chatId, resposta, ct);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERRO] {ex.Message}");
        await bot.SendMessage(chatId, $"Ocorreu um erro: {ex.Message}", cancellationToken: ct);
    }
    finally
    {
        chatLock.Release();
    }
}

async Task HandleError(ITelegramBotClient bot, Exception ex, HandleErrorSource source, CancellationToken ct)
{
    Console.WriteLine($"[ERRO Telegram] {source}: {ex.Message}");
    await Task.CompletedTask;
}

using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

telegram.StartReceiving(
    updateHandler: HandleUpdate,
    errorHandler: HandleError,
    receiverOptions: new ReceiverOptions
    {
        AllowedUpdates = [UpdateType.Message],
        DropPendingUpdates = true,
    },
    cancellationToken: cts.Token
);

await Task.Delay(Timeout.Infinite, cts.Token).ContinueWith(_ => { });
Console.WriteLine("\nBot encerrado.");
