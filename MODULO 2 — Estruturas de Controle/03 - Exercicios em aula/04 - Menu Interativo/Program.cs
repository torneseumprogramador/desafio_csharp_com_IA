int pontuacao = 0;
while (true)
{
    Console.Clear();
    Console.WriteLine("1 - Adicionar 10 pontos");
    Console.WriteLine("2 - Remover 5 pontos");
    Console.WriteLine("3 - Mostrar pontuação atual");
    Console.WriteLine("4 - Zerar pontuação");
    Console.WriteLine("5 - Dobrar pontuação");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Digite uma das opções acima: ");
    
    string entrada = Console.ReadLine() ?? "";
    int opcao;
    if (!int.TryParse(entrada, out opcao))
    {
        Console.WriteLine("Opção inválida");
        System.Threading.Thread.Sleep(2000);
        continue;
    }

    if (opcao == 0)
        break;

    Console.Clear();

    switch (opcao)
    {
        case 1:
            pontuacao += 10;
            break;
        case 2:
            if (pontuacao >= 5)
            {
                pontuacao -= 5;
            }
            else
            {
                Console.WriteLine("A pontuação não pode ficar negativa!");
                System.Threading.Thread.Sleep(2000);
            }
            break;
        case 3:
            Console.Clear();
            Console.WriteLine($"Pontuação atual: {pontuacao}");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            break;
        case 4:
            pontuacao = 0;
            break;
        case 5:
            pontuacao *= 2;
            break;
        default:
            Console.WriteLine("Opção inválida");
            System.Threading.Thread.Sleep(2000);
            break;
    }
}

Console.Clear();
Console.WriteLine($"Pontuação final: {pontuacao}");
string resultado = pontuacao > 50 ? "Boa pontuação!" : "Você pode melhorar!";
Console.WriteLine(resultado);