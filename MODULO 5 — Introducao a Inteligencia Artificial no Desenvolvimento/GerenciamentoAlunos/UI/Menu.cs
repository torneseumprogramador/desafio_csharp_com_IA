using GerenciamentoAlunos.Services;

namespace GerenciamentoAlunos.UI;

public class Menu(AlunoService service)
{
    private readonly AlunoService _service = service;

    public void Executar()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Cabecalho();

        bool executando = true;
        while (executando)
        {
            MostrarMenu();
            var opcao = Console.ReadLine()?.Trim();
            Console.WriteLine();

            executando = opcao switch
            {
                "1" => Cadastrar(),
                "2" => ListarAlunos(),
                "3" => BuscarAluno(),
                "4" => AdicionarNota(),
                "5" => AtualizarAluno(),
                "6" => RemoverAluno(),
                "7" => Relatorio(),
                "0" => Sair(),
                _ => OpcaoInvalida()
            };
        }
    }

    private static void Cabecalho()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║    SISTEMA DE GERENCIAMENTO DE       ║");
        Console.WriteLine("║            ALUNOS v1.0               ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void MostrarMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("┌─────────────────────────────┐");
        Console.WriteLine("│           MENU              │");
        Console.WriteLine("├─────────────────────────────┤");
        Console.WriteLine("│  1. Cadastrar aluno         │");
        Console.WriteLine("│  2. Listar alunos           │");
        Console.WriteLine("│  3. Buscar aluno            │");
        Console.WriteLine("│  4. Adicionar nota          │");
        Console.WriteLine("│  5. Atualizar aluno         │");
        Console.WriteLine("│  6. Remover aluno           │");
        Console.WriteLine("│  7. Relatório da turma      │");
        Console.WriteLine("│  0. Sair                    │");
        Console.WriteLine("└─────────────────────────────┘");
        Console.ResetColor();
        Console.Write("Opção: ");
    }

    private bool Cadastrar()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── CADASTRAR ALUNO ──");
        Console.ResetColor();

        Console.Write("Nome  : ");
        var nome = Console.ReadLine() ?? "";

        Console.Write("Email : ");
        var email = Console.ReadLine() ?? "";

        Console.Write("Idade : ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Erro("Idade inválida.");
            return true;
        }

        var (sucesso, mensagem, aluno) = _service.Cadastrar(nome, email, idade);
        if (sucesso)
        {
            Sucesso(mensagem);
            Console.WriteLine(aluno);
        }
        else
            Erro(mensagem);

        Pausar();
        return true;
    }

    private bool ListarAlunos()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── LISTA DE ALUNOS ──");
        Console.ResetColor();

        var alunos = _service.ListarTodos();
        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            foreach (var aluno in alunos)
            {
                var cor = aluno.Situacao switch
                {
                    "Aprovado" => ConsoleColor.Green,
                    "Recuperação" => ConsoleColor.Yellow,
                    _ => ConsoleColor.Red
                };
                Console.ForegroundColor = cor;
                Console.WriteLine(aluno);
                Console.ResetColor();
            }
            Console.WriteLine($"\nTotal: {alunos.Count} aluno(s)");
        }

        Pausar();
        return true;
    }

    private bool BuscarAluno()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── BUSCAR ALUNO ──");
        Console.ResetColor();
        Console.WriteLine("  1. Por ID");
        Console.WriteLine("  2. Por nome");
        Console.Write("Opção: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                Console.Write("ID: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                { Erro("ID inválido."); break; }
                var aluno = _service.BuscarPorId(id);
                if (aluno is null) Erro("Aluno não encontrado.");
                else ExibirDetalhe(aluno);
                break;

            case "2":
                Console.Write("Nome: ");
                var nome = Console.ReadLine() ?? "";
                var lista = _service.BuscarPorNome(nome);
                if (lista.Count == 0) Erro("Nenhum aluno encontrado.");
                else foreach (var a in lista) Console.WriteLine(a);
                break;

            default:
                Erro("Opção inválida.");
                break;
        }

        Pausar();
        return true;
    }

    private bool AdicionarNota()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── ADICIONAR NOTA ──");
        Console.ResetColor();

        Console.Write("ID do aluno : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        { Erro("ID inválido."); Pausar(); return true; }

        Console.Write("Nota (0-10) : ");
        if (!double.TryParse(Console.ReadLine()?.Replace(',', '.'), System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double nota))
        { Erro("Nota inválida."); Pausar(); return true; }

        var (sucesso, mensagem) = _service.AdicionarNota(id, nota);
        if (sucesso) Sucesso(mensagem);
        else Erro(mensagem);

        Pausar();
        return true;
    }

    private bool AtualizarAluno()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── ATUALIZAR ALUNO ──");
        Console.ResetColor();

        Console.Write("ID do aluno : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        { Erro("ID inválido."); Pausar(); return true; }

        var aluno = _service.BuscarPorId(id);
        if (aluno is null) { Erro("Aluno não encontrado."); Pausar(); return true; }

        Console.WriteLine($"Dados atuais: {aluno}");
        Console.WriteLine("(Deixe em branco para manter o valor atual)");

        Console.Write($"Nome [{aluno.Nome}]: ");
        var nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome)) nome = aluno.Nome;

        Console.Write($"Email [{aluno.Email}]: ");
        var email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email)) email = aluno.Email;

        Console.Write($"Idade [{aluno.Idade}]: ");
        var idadeStr = Console.ReadLine();
        var idade = string.IsNullOrWhiteSpace(idadeStr) ? aluno.Idade : int.Parse(idadeStr);

        var (sucesso, mensagem) = _service.AtualizarDados(id, nome, email, idade);
        if (sucesso) Sucesso(mensagem);
        else Erro(mensagem);

        Pausar();
        return true;
    }

    private bool RemoverAluno()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("── REMOVER ALUNO ──");
        Console.ResetColor();

        Console.Write("ID do aluno: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        { Erro("ID inválido."); Pausar(); return true; }

        var aluno = _service.BuscarPorId(id);
        if (aluno is null) { Erro("Aluno não encontrado."); Pausar(); return true; }

        Console.WriteLine($"Confirmar remoção de: {aluno}");
        Console.Write("Confirmar? (s/N): ");
        if (Console.ReadLine()?.Trim().ToLower() != "s")
        { Console.WriteLine("Operação cancelada."); Pausar(); return true; }

        var (sucesso, mensagem) = _service.Remover(id);
        if (sucesso) Sucesso(mensagem);
        else Erro(mensagem);

        Pausar();
        return true;
    }

    private bool Relatorio()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(_service.GerarRelatorio());
        Console.ResetColor();
        Pausar();
        return true;
    }

    private static bool Sair()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Encerrando o sistema. Até logo!");
        Console.ResetColor();
        return false;
    }

    private static bool OpcaoInvalida()
    {
        Erro("Opção inválida. Tente novamente.");
        Pausar();
        return true;
    }

    private void ExibirDetalhe(Models.Aluno aluno)
    {
        Console.WriteLine($"""
            ─────────────────────────────
            ID    : {aluno.Id}
            Nome  : {aluno.Nome}
            Email : {aluno.Email}
            Idade : {aluno.Idade}
            Notas : {(aluno.Notas.Count > 0 ? string.Join(", ", aluno.Notas.Select(n => n.ToString("F1"))) : "Sem notas")}
            Média : {aluno.Media:F1}
            Status: {aluno.Situacao}
            ─────────────────────────────
            """);
    }

    private static void Sucesso(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✓ {msg}");
        Console.ResetColor();
    }

    private static void Erro(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ {msg}");
        Console.ResetColor();
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.Write("Pressione Enter para continuar...");
        Console.ReadLine();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║    SISTEMA DE GERENCIAMENTO DE       ║");
        Console.WriteLine("║            ALUNOS v1.0               ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
}
