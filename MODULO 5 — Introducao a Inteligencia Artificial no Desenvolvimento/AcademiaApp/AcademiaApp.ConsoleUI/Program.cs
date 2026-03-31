using System;
using System.Globalization;
using AcademiaApp.Application.Services;
using AcademiaApp.Infrastructure.Repositories;

namespace AcademiaApp.ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        // Dependency Injection manually
        var repository = new AlunoRepository();
        var service = new AlunoService(repository);

        bool rodando = true;

        while (rodando)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("    GERENCIAMENTO DE ACADEMIA 🏋️‍♂️💪     ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Cadastrar Novo Aluno");
            Console.WriteLine("2. Listar Todos os Alunos");
            Console.WriteLine("3. Buscar Aluno por ID");
            Console.WriteLine("4. Atualizar Dados do Aluno");
            Console.WriteLine("5. Inativar Aluno");
            Console.WriteLine("6. Excluir Aluno");
            Console.WriteLine("0. Sair");
            Console.WriteLine("========================================");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        CadastrarAluno(service);
                        break;
                    case "2":
                        ListarAlunos(service);
                        break;
                    case "3":
                        BuscarAluno(service);
                        break;
                    case "4":
                        AtualizarAluno(service);
                        break;
                    case "5":
                        InativarAluno(service);
                        break;
                    case "6":
                        ExcluirAluno(service);
                        break;
                    case "0":
                        rodando = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO] {ex.Message}");
            }

            if (rodando)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private static void CadastrarAluno(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- CADASTRAR ALUNO ---");
        
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
        {
            throw new Exception("Data de nascimento inválida. Use o formato dd/mm/aaaa.");
        }

        Console.Write("Peso (kg): ");
        if (!double.TryParse(Console.ReadLine()?.Replace(",", "."), CultureInfo.InvariantCulture, out double peso))
        {
            throw new Exception("Peso inválido.");
        }

        Console.Write("Altura (m): ");
        if (!double.TryParse(Console.ReadLine()?.Replace(",", "."), CultureInfo.InvariantCulture, out double altura))
        {
            throw new Exception("Altura inválida.");
        }

        service.CadastrarAluno(nome, dataNascimento, peso, altura);
        Console.WriteLine("\n✅ Aluno cadastrado com sucesso!");
    }

    private static void ListarAlunos(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE ALUNOS ---");
        
        var alunos = service.ListarAlunos();
        bool temAluno = false;

        foreach (var aluno in alunos)
        {
            temAluno = true;
            Console.WriteLine($"ID: {aluno.Id} | Nome: {aluno.Nome} | Status: {aluno.Status} | Idade: {aluno.CalcularIdade()} anos | IMC: {aluno.CalcularIMC():F2}");
        }

        if (!temAluno)
        {
            Console.WriteLine("Nenhum aluno cadastrado no sistema.");
        }
    }

    private static void BuscarAluno(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- BUSCAR ALUNO ---");
        Console.Write("Informe o ID do aluno: ");
        
        if (!int.TryParse(Console.ReadLine(), out int id))
            throw new Exception("ID inválido.");

        var aluno = service.ObterAluno(id);
        
        Console.WriteLine("\nDados do Aluno:");
        Console.WriteLine($"ID: {aluno.Id}");
        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"Data Nascimento: {aluno.DataNascimento:dd/MM/yyyy} ({aluno.CalcularIdade()} anos)");
        Console.WriteLine($"Status: {aluno.Status}");
        Console.WriteLine($"Peso: {aluno.Peso} kg");
        Console.WriteLine($"Altura: {aluno.Altura} m");
        Console.WriteLine($"IMC: {aluno.CalcularIMC():F2}");
    }

    private static void AtualizarAluno(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- ATUALIZAR ALUNO ---");
        Console.Write("Informe o ID do aluno que deseja atualizar: ");
        
        if (!int.TryParse(Console.ReadLine(), out int id))
            throw new Exception("ID inválido.");

        // Verificar se existe
        service.ObterAluno(id);

        Console.Write("Novo Nome (deixe em branco para não alterar): ");
        string nome = Console.ReadLine();

        Console.Write("Novo Peso (deixe em branco para não alterar): ");
        string pesoStr = Console.ReadLine();
        double peso = 0;
        if (!string.IsNullOrWhiteSpace(pesoStr))
        {
            if (!double.TryParse(pesoStr.Replace(",", "."), CultureInfo.InvariantCulture, out peso))
                throw new Exception("Peso inválido.");
        }

        Console.Write("Nova Altura (deixe em branco para não alterar): ");
        string alturaStr = Console.ReadLine();
        double altura = 0;
        if (!string.IsNullOrWhiteSpace(alturaStr))
        {
            if (!double.TryParse(alturaStr.Replace(",", "."), CultureInfo.InvariantCulture, out altura))
                throw new Exception("Altura inválida.");
        }

        service.AtualizarAluno(id, nome, peso, altura);
        Console.WriteLine("\n✅ Aluno atualizado com sucesso!");
    }

    private static void InativarAluno(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- INATIVAR ALUNO ---");
        Console.Write("Informe o ID do aluno: ");
        
        if (!int.TryParse(Console.ReadLine(), out int id))
            throw new Exception("ID inválido.");

        service.InativarAluno(id);
        Console.WriteLine("\n✅ Aluno inativado com sucesso!");
    }

    private static void ExcluirAluno(IAlunoService service)
    {
        Console.Clear();
        Console.WriteLine("--- EXCLUIR ALUNO ---");
        Console.Write("Informe o ID do aluno: ");
        
        if (!int.TryParse(Console.ReadLine(), out int id))
            throw new Exception("ID inválido.");

        service.ExcluirAluno(id);
        Console.WriteLine("\n✅ Aluno excluído com sucesso!");
    }
}
