class Menu
{
    // uma classe é um elemento que vc cria para orgnizar funçoes(pequenos algotitimos) ou propriedades (variáveis) em um arquivo
    public static void executarOpcoes()
    {
        while (true)
        {
            Console.WriteLine("Digite uma das opções abaixo: ");
            Console.WriteLine("1 - Tabuada");
            Console.WriteLine("2 - Cadastro de usuário e listagem de usuários");
            Console.WriteLine("3 - Captura de números e mostra quais destes numeros sao pares e quais sao impares");
            Console.WriteLine("4 - Sair");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int opcao))
            {
                Console.WriteLine("Opção inválida");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Algoritimos.Tabuada.Tabuada.executar();
                    break;
                case 2:
                    Algoritimos.Usuarios.Menu.executar();
                    break;
                case 3:
                    Algoritimos.NumerosPares.Numero.executar();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}