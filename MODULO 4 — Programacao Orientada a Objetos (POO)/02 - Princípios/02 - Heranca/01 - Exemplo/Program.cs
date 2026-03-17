// herança é quando quero reaproveitar métodos ou propriedades de uma classe pai para uma classe filha
class Pessoa
{
    public string Nome { get; set; }
    public long Documento { get; set; }

    protected bool EhPessoaFisica()
    {
        return Documento.ToString().Length == 11;
    }
}

class PessoaFisica : Pessoa
{
    public string RG { get; set; }
}

class PessoaJuridica : Pessoa
{
    public string InscricaoEstadual { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------");
        PessoaFisica pessoa = new PessoaFisica();
        pessoa.Nome = "João";
        pessoa.Documento = 12345678901; // 11 dígitos para CPF
        pessoa.RG = "1234567890";

        Console.WriteLine("Nome: " + pessoa.Nome);
        Console.WriteLine("Documento: " + pessoa.Documento);
        Console.WriteLine("É pessoa física: Sim" );
        Console.WriteLine("--------------------------------");

        PessoaJuridica empresa = new PessoaJuridica();
        empresa.Nome = "Empresa";
        empresa.Documento = 23322233322323; // 14 dígitos para CNPJ
        empresa.InscricaoEstadual = "1234567890";

        Console.WriteLine("Nome: " + empresa.Nome);
        Console.WriteLine("Documento: " + empresa.Documento);
        Console.WriteLine("É pessoa jurídica: Sim");

        
        Console.WriteLine("--------------------------------");
    }
}