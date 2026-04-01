namespace Erros;
class SomenteNumerosException : Exception
{
    public SomenteNumerosException() : base("Somente números são permitidos")
    {
    }

    public SomenteNumerosException(string message) : base(message)
    {
    }
}