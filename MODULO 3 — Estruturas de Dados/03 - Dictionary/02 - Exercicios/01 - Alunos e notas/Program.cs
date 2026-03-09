List<Dictionary<string, object>> alunos = new List<Dictionary<string, object>>();
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

            Console.WriteLine("Digite a matrícula do aluno: ");
            string matricula = Console.ReadLine() ?? "";

            Console.WriteLine("Digite as 3 notas do aluno: ");
            double[] notas = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Digite a nota {i + 1}: ");
                notas[i] = double.Parse(Console.ReadLine() ?? "0");
            }

            var novoAluno = new Dictionary<string, object>();
            novoAluno.Add("nome", nome);
            novoAluno.Add("matricula", matricula);
            novoAluno.Add("notas", notas);
            
            alunos.Add(novoAluno);
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Relatório de alunos");
            Console.WriteLine("------------Versão com foreach--------------------");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Nome: {aluno["nome"]}"); 
                Console.WriteLine($"Matrícula: {aluno["matricula"]}"); 

                var notasDoAluno = (double[])aluno["notas"];
                Console.WriteLine($"Notas: {string.Join(", ", notasDoAluno)}");
                Console.WriteLine($"Média: {notasDoAluno?.Average().ToString("0.00")}");

                if (notasDoAluno?.Average() >= 7)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aluno aprovado");
                }
                else if (notasDoAluno?.Average() >= 5 && notasDoAluno?.Average() < 7)
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