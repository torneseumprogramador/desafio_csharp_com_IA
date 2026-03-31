using EstoqueApp.Application.Repositories;
using EstoqueApp.Application.Services;
using EstoqueApp.Domain.Enums;
using EstoqueApp.Domain.Models;

var filePath = Path.Combine(AppContext.BaseDirectory, "produtos.json");
var repository = new ProdutoJsonRepository(filePath);
var service = new ProdutoService(repository);

while (true)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("       GERENCIADOR DE ESTOQUE           ");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Listar todos os produtos");
    Console.WriteLine("2. Buscar produto por ID");
    Console.WriteLine("3. Cadastrar produto");
    Console.WriteLine("4. Editar produto");
    Console.WriteLine("5. Remover produto");
    Console.WriteLine("6. Atualizar estoque (entrada/saída)");
    Console.WriteLine("7. Listar por categoria");
    Console.WriteLine("8. Alertas de estoque baixo");
    Console.WriteLine("0. Sair");
    Console.WriteLine("========================================");
    Console.Write("Opção: ");

    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1": ListarTodos(); break;
            case "2": BuscarPorId(); break;
            case "3": CadastrarProduto(); break;
            case "4": EditarProduto(); break;
            case "5": RemoverProduto(); break;
            case "6": AtualizarEstoque(); break;
            case "7": ListarPorCategoria(); break;
            case "8": AlertaEstoqueBaixo(); break;
            case "0": Console.WriteLine("Até logo!"); return;
            default: Console.WriteLine("Opção inválida."); break;
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nErro: {ex.Message}");
        Console.ResetColor();
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

// ── Helpers ──────────────────────────────────────────────

void ListarTodos()
{
    var produtos = service.ListarTodos().ToList();
    if (produtos.Count == 0) { Console.WriteLine("\nNenhum produto cadastrado."); return; }
    ImprimirTabela(produtos);
}

void BuscarPorId()
{
    Console.Write("\nID do produto: ");
    if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido."); return; }

    var produto = service.BuscarPorId(id);
    if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }
    ImprimirDetalhe(produto);
}

void CadastrarProduto()
{
    Console.WriteLine("\n--- Cadastrar Produto ---");
    var produto = LerDadosProduto(new Produto());
    service.Cadastrar(produto);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Produto cadastrado com sucesso!");
    Console.ResetColor();
}

void EditarProduto()
{
    Console.Write("\nID do produto a editar: ");
    if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido."); return; }

    var produto = service.BuscarPorId(id);
    if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }

    Console.WriteLine("\n--- Editar Produto (Enter para manter o valor atual) ---");
    var atualizado = LerDadosProduto(produto, editando: true);
    service.Atualizar(atualizado);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Produto atualizado com sucesso!");
    Console.ResetColor();
}

void RemoverProduto()
{
    Console.Write("\nID do produto a remover: ");
    if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido."); return; }

    var produto = service.BuscarPorId(id);
    if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }

    Console.Write($"Confirmar remoção de '{produto.Nome}'? (s/n): ");
    if (Console.ReadLine()?.Trim().ToLower() != "s") { Console.WriteLine("Operação cancelada."); return; }

    service.Remover(id);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Produto removido com sucesso!");
    Console.ResetColor();
}

void AtualizarEstoque()
{
    Console.Write("\nID do produto: ");
    if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido."); return; }

    var produto = service.BuscarPorId(id);
    if (produto is null) { Console.WriteLine("Produto não encontrado."); return; }

    Console.WriteLine($"Estoque atual de '{produto.Nome}': {produto.QuantidadeEstoque}");
    Console.Write("Quantidade (positivo = entrada, negativo = saída): ");
    if (!int.TryParse(Console.ReadLine(), out var qtd)) { Console.WriteLine("Valor inválido."); return; }

    service.AtualizarEstoque(id, qtd);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Estoque atualizado! Novo saldo: {produto.QuantidadeEstoque + qtd}");
    Console.ResetColor();
}

void ListarPorCategoria()
{
    Console.WriteLine("\nCategorias disponíveis:");
    foreach (var cat in Enum.GetValues<Categoria>())
        Console.WriteLine($"  {(int)cat}. {cat}");

    Console.Write("Escolha a categoria: ");
    if (!int.TryParse(Console.ReadLine(), out var num) || !Enum.IsDefined(typeof(Categoria), num))
    { Console.WriteLine("Categoria inválida."); return; }

    var categoria = (Categoria)num;
    var produtos = service.ListarPorCategoria(categoria).ToList();
    if (produtos.Count == 0) { Console.WriteLine($"\nNenhum produto na categoria {categoria}."); return; }
    ImprimirTabela(produtos);
}

void AlertaEstoqueBaixo()
{
    Console.Write("\nLimite mínimo de estoque (padrão 5): ");
    var input = Console.ReadLine();
    var limite = string.IsNullOrWhiteSpace(input) ? 5 : int.Parse(input);

    var produtos = service.ListarEstoqueBaixo(limite).ToList();
    if (produtos.Count == 0) { Console.WriteLine($"\nNenhum produto com estoque <= {limite}."); return; }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\n⚠  {produtos.Count} produto(s) com estoque baixo (≤ {limite}):");
    Console.ResetColor();
    ImprimirTabela(produtos);
}

Produto LerDadosProduto(Produto base_, bool editando = false)
{
    Console.Write($"Nome{(editando ? $" [{base_.Nome}]" : "")}: ");
    var nome = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nome)) base_.Nome = nome;

    Console.Write($"Descrição{(editando ? $" [{base_.Descricao}]" : "")}: ");
    var desc = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(desc)) base_.Descricao = desc;

    Console.Write($"Preço{(editando ? $" [{base_.Preco:F2}]" : "")}: ");
    var precoStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(precoStr) && decimal.TryParse(precoStr, out var preco))
        base_.Preco = preco;

    Console.Write($"Quantidade em estoque{(editando ? $" [{base_.QuantidadeEstoque}]" : "")}: ");
    var qtdStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(qtdStr) && int.TryParse(qtdStr, out var qtd))
        base_.QuantidadeEstoque = qtd;

    Console.WriteLine("Categorias:");
    foreach (var cat in Enum.GetValues<Categoria>())
        Console.WriteLine($"  {(int)cat}. {cat}");
    Console.Write($"Categoria{(editando ? $" [{base_.Categoria}]" : "")}: ");
    var catStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(catStr) && int.TryParse(catStr, out var catNum) && Enum.IsDefined(typeof(Categoria), catNum))
        base_.Categoria = (Categoria)catNum;

    return base_;
}

void ImprimirTabela(IEnumerable<Produto> produtos)
{
    Console.WriteLine();
    Console.WriteLine($"{"ID",-5} {"Nome",-25} {"Categoria",-15} {"Preço",10} {"Estoque",8}");
    Console.WriteLine(new string('-', 68));
    foreach (var p in produtos)
        Console.WriteLine($"{p.Id,-5} {p.Nome,-25} {p.Categoria,-15} {p.Preco,10:C} {p.QuantidadeEstoque,8}");
}

void ImprimirDetalhe(Produto p)
{
    Console.WriteLine();
    Console.WriteLine($"ID:           {p.Id}");
    Console.WriteLine($"Nome:         {p.Nome}");
    Console.WriteLine($"Descrição:    {p.Descricao}");
    Console.WriteLine($"Categoria:    {p.Categoria}");
    Console.WriteLine($"Preço:        {p.Preco:C}");
    Console.WriteLine($"Estoque:      {p.QuantidadeEstoque}");
    Console.WriteLine($"Cadastrado:   {p.DataCadastro:dd/MM/yyyy HH:mm}");
}
