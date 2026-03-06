List<(string nome, double[] notas)> alunos = new List<(string, double[])>();
while (true)
{
    Console.Clear();
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Cadastrar novo aluno");
    Console.WriteLine("2 - Exibir relatório de alunos");
    Console.WriteLine("3 - Sair");
    Console.WriteLine("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine() ?? "0");
    
    switch (opcao)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Digite o nome do aluno: ");
            string nome = Console.ReadLine() ?? "";
            Console.WriteLine("Digite as 3 notas do aluno: ");
            double[] notas = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Digite a nota {i + 1}: ");
                notas[i] = double.Parse(Console.ReadLine() ?? "0");
            }

            alunos.Add((nome, notas));
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Relatório de alunos");
            Console.WriteLine("------------Versão com foreach--------------------");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Nome: {aluno.nome}");  
                Console.WriteLine($"Notas: {string.Join(", ", aluno.notas)}");
                Console.WriteLine($"Média: {aluno.notas.Average().ToString("0.00")}");
                if (aluno.notas.Average() >= 7)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aluno aprovado");
                }
                else if (aluno.notas.Average() >= 5 && aluno.notas.Average() < 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aluno em recuperação");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Aluno reprovado");
                }
                Console.ResetColor();
                Console.WriteLine("--------------------------------");
            }

            Console.WriteLine("Pressione enter para continuar");
            Console.ReadLine();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Sair");
            return;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}