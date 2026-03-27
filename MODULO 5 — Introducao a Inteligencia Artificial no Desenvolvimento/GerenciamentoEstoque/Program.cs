using GerenciamentoEstoque;

var estoque = new Estoque();

// Dados iniciais para teste
estoque.AdicionarProduto("Notebook Dell", "Informática", 3499.90, 10);
estoque.AdicionarProduto("Mouse Logitech", "Informática", 89.90, 50);
estoque.AdicionarProduto("Cadeira Gamer", "Móveis", 1299.00, 5);
estoque.AdicionarProduto("Monitor 24\"", "Informática", 899.00, 3);
estoque.AdicionarProduto("Teclado Mecânico", "Informática", 349.90, 0);

while (true)
{
    ExibirMenu();
    string opcao = Console.ReadLine()?.Trim() ?? "";

    switch (opcao)
    {
        case "1":
            AdicionarProduto();
            break;
        case "2":
            estoque.ListarProdutos();
            break;
        case "3":
            BuscarProduto();
            break;
        case "4":
            AtualizarQuantidade();
            break;
        case "5":
            AtualizarPreco();
            break;
        case "6":
            RemoverProduto();
            break;
        case "7":
            estoque.ExibirRelatorio();
            break;
        case "0":
            Console.WriteLine("\n Encerrando sistema. Até logo!\n");
            return;
        default:
            Console.WriteLine("\n Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine("\n Pressione ENTER para continuar...");
    Console.ReadLine();
    Console.Clear();
}

void ExibirMenu()
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
    Console.WriteLine("      SISTEMA DE GERENCIAMENTO DE ESTOQUE");
    Console.WriteLine(new string('=', 45));
    Console.WriteLine("  1. Adicionar produto");
    Console.WriteLine("  2. Listar todos os produtos");
    Console.WriteLine("  3. Buscar produto");
    Console.WriteLine("  4. Atualizar quantidade");
    Console.WriteLine("  5. Atualizar preço");
    Console.WriteLine("  6. Remover produto");
    Console.WriteLine("  7. Relatório do estoque");
    Console.WriteLine("  0. Sair");
    Console.WriteLine(new string('-', 45));
    Console.Write("  Escolha uma opção: ");
}

void AdicionarProduto()
{
    Console.WriteLine("\n --- ADICIONAR PRODUTO ---");
    Console.Write(" Nome: ");
    string nome = Console.ReadLine() ?? "";

    Console.Write(" Categoria: ");
    string categoria = Console.ReadLine() ?? "";

    Console.Write(" Preço (ex: 99,90): ");
    if (!double.TryParse(Console.ReadLine(), out double preco) || preco < 0)
    {
        Console.WriteLine(" Preço inválido.");
        return;
    }

    Console.Write(" Quantidade: ");
    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
    {
        Console.WriteLine(" Quantidade inválida.");
        return;
    }

    estoque.AdicionarProduto(nome, categoria, preco, quantidade);
}

void BuscarProduto()
{
    Console.WriteLine("\n --- BUSCAR PRODUTO ---");
    Console.Write(" Digite o nome ou categoria: ");
    string termo = Console.ReadLine() ?? "";
    estoque.BuscarProduto(termo);
}

void AtualizarQuantidade()
{
    Console.WriteLine("\n --- ATUALIZAR QUANTIDADE ---");
    Console.Write(" ID do produto: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine(" ID inválido.");
        return;
    }

    Console.Write(" Nova quantidade: ");
    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
    {
        Console.WriteLine(" Quantidade inválida.");
        return;
    }

    estoque.AtualizarQuantidade(id, quantidade);
}

void AtualizarPreco()
{
    Console.WriteLine("\n --- ATUALIZAR PREÇO ---");
    Console.Write(" ID do produto: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine(" ID inválido.");
        return;
    }

    Console.Write(" Novo preço (ex: 199,90): ");
    if (!double.TryParse(Console.ReadLine(), out double preco) || preco < 0)
    {
        Console.WriteLine(" Preço inválido.");
        return;
    }

    estoque.AtualizarPreco(id, preco);
}

void RemoverProduto()
{
    Console.WriteLine("\n --- REMOVER PRODUTO ---");
    Console.Write(" ID do produto: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine(" ID inválido.");
        return;
    }

    estoque.RemoverProduto(id);
}
