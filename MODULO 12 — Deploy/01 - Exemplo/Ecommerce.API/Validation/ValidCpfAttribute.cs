using System.ComponentModel.DataAnnotations;
using primeiraApi.ValueObjects;

namespace primeiraApi.Validation;

public class ValidCpfAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string cpf || string.IsNullOrWhiteSpace(cpf))
        {
            return false;
        }

        try
        {
            _ = new Cpf(cpf);
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
