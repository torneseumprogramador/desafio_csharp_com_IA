namespace Erros;
class CNPJValidationException : Exception
{
    public CNPJValidationException() : base("CNPJ inválido")
    {
    }

    public CNPJValidationException(string message) : base(message)
    {
    }
}