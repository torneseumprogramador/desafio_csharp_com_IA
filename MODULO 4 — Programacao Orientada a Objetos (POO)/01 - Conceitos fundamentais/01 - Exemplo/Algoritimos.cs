class Algoritimos
{
    // uma classe é um elemento que vc cria para orgnizar funçoes(pequenos algotitimos) ou propriedades (variáveis) em um arquivo
    public static void executarTabuada()
    {
        Console.WriteLine("Digite um número para gerar a tabuada: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int numero))
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
        }
    }

    public static void executarCadastroDeUsuario()
    {
        List<string> usuarios = new List<string>();
        while (true)
        {
            Console.WriteLine("Digite o nome do usuário: ");
            string? nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
            {
                usuarios.Add(nome);
            }
            else
            {
                Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
                continue;
            }
            Console.WriteLine("Deseja cadastrar outro usuário? (s/n)");
            string? resposta = Console.ReadLine();
            if (resposta != null && resposta.Trim().ToLower() == "n")
            {
                break;
            }
        }

        Console.WriteLine("Lista de usuários: ");
        foreach (string usuario in usuarios)
        {
            Console.WriteLine(usuario);
        }
    }

    public static void executarCapturaDeNumeros()
    {
        Console.WriteLine("Digite um número: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int numero))
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine("O número é par");
            }
            else
            {
                Console.WriteLine("O número é ímpar");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
        }
    }
}