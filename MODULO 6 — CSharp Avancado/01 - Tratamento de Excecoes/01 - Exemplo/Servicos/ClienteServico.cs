using Erros;
using Models;

namespace Servicos;

public class ClienteServico
{
    public void ValidarCliente(Cliente cliente)
    {
        ValidarCampoObrigatorio(cliente.Nome, "Nome");
        ValidarCampoObrigatorio(cliente.Cpf, "CPF");
        ValidarCampoObrigatorio(cliente.Cnpj, "CNPJ");

        ValidarSomenteNumeros(cliente.Cpf, "CPF");
        ValidarSomenteNumeros(cliente.Cnpj, "CNPJ");

        ValidarCpf(cliente.Cpf);
        ValidarCnpj(cliente.Cnpj);
    }

    private static void ValidarCampoObrigatorio(string valor, string nomeCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new VazioException($"O campo {nomeCampo} não pode ser vazio.");
        }
    }

    private static void ValidarSomenteNumeros(string valor, string nomeCampo)
    {
        if (!valor.All(char.IsDigit))
        {
            throw new SomenteNumerosException($"O campo {nomeCampo} deve conter somente números.");
        }
    }

    private static void ValidarCpf(string cpf)
    {
        if (cpf.Length != 11)
        {
            throw new CPFValidationException("O CPF deve conter 11 números.");
        }
    }

    private static void ValidarCnpj(string cnpj)
    {
        if (cnpj.Length != 14)
        {
            throw new CNPJValidationException("O CNPJ deve conter 14 números.");
        }
    }
}
