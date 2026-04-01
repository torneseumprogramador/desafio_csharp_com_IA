namespace Erros;
class VazioException : Exception
{
    public VazioException() : base("Campo vazio")
    {
    }

    public VazioException(string message) : base(message)
    {
    }
}