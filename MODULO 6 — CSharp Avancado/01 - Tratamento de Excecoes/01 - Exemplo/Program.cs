// try
// {
//     // int a = 10;
//     // int b = 0;
//     // int resultado = a / b;
//     // int resultado = int.Parse("10s");
//     // Console.WriteLine(resultado);
//     throw new Erros.VazioException();
//     // throw new Exception("errrrs teste");
// }
// catch (System.DivideByZeroException ex)
// {
//     Console.WriteLine("Class: " + ex.GetType());
//     Console.WriteLine("Message: " + ex.Message);
//     Console.WriteLine("StackTrace: " + ex.StackTrace);
// }
// catch (Erros.VazioException ex)
// {
//     Console.WriteLine("O campo não pode ser vazio: " + ex.Message);
// }
// catch (Exception ex)
// {
//     Console.WriteLine("Aconteceu um erro genérico: " + ex.Message);
//     Console.WriteLine("Class: " + ex.GetType());
// }
// finally
// {
//     Console.WriteLine("Finalizando o programa");
// }



using Erros;
using Models;
using Servicos;

var clienteServico = new ClienteServico();

ExecutarExemplo(
    "Erro de campo vazio",
    new Cliente { Nome = "", Cpf = "12345678901", Cnpj = "12345678000199" },
    clienteServico);

ExecutarExemplo(
    "Erro de somente números",
    new Cliente { Nome = "Maria", Cpf = "1234567890A", Cnpj = "12345678000199" },
    clienteServico);

ExecutarExemplo(
    "Erro de CPF inválido",
    new Cliente { Nome = "Joao", Cpf = "12345", Cnpj = "12345678000199" },
    clienteServico);

ExecutarExemplo(
    "Erro de CNPJ inválido",
    new Cliente { Nome = "Ana", Cpf = "12345678901", Cnpj = "12345678" },
    clienteServico);

ExecutarExemplo(
    "Cliente válido",
    new Cliente { Nome = "Carlos", Cpf = "12345678901", Cnpj = "12345678000199" },
    clienteServico);

static void ExecutarExemplo(string titulo, Cliente cliente, ClienteServico clienteServico)
{
    Console.WriteLine($"\n--- {titulo} ---");

    try
    {
        clienteServico.ValidarCliente(cliente);
        Console.WriteLine("Cliente validado com sucesso.");
    }
    catch (VazioException ex)
    {
        Console.WriteLine("VazioException: " + ex.Message);
    }
    catch (SomenteNumerosException ex)
    {
        Console.WriteLine("SomenteNumerosException: " + ex.Message);
    }
    catch (CPFValidationException ex)
    {
        Console.WriteLine("CPFValidationException: " + ex.Message);
    }
    catch (CNPJValidationException ex)
    {
        Console.WriteLine("CNPJValidationException: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro genérico: " + ex.Message);
    }
    finally
    {
        Console.WriteLine("Finalizando o exemplo.");
    }
}