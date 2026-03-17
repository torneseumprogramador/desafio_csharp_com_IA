// Polimorfismo é o a modificação de um método ou propriedade de uma classe pai para uma classe filha deixando a classe filha com as suas caractetisticas

class Pessoa
{
    public string Nome { get; set; }
    public long Documento { get; set; }

    public virtual bool EhPessoaFisica()
    {
        return Documento.ToString().Length == 11;
    }

    public virtual string TipoPessoa()
    {
        return "Pessoa";
    }
}

class PessoaFisica : Pessoa
{
    public string RG { get; set; }

    public override bool EhPessoaFisica()
    {
        // var valorOriginal = base.EhPessoaFisica(); // captura o valor original do método EhPessoaFisica da classe Pessoa
        return true;
    }

    public override string TipoPessoa()
    {
        return "Pessoa Física";
    }
}

class PessoaJuridica : Pessoa
{
    public string InscricaoEstadual { get; set; }

    public override bool EhPessoaFisica()
    {
        return false;
    }

    public override string TipoPessoa()
    {
        return "Pessoa Jurídica";
    }
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