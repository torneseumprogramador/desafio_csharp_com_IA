namespace Erros;
class CPFValidationException : Exception
{
    public CPFValidationException() : base("CPF inválido")
    {
    }

    public CPFValidationException(string message) : base(message)
    {
    }
}