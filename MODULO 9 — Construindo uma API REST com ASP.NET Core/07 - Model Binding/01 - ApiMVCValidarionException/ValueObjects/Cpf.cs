namespace primeiraApi.ValueObjects;

public readonly record struct Cpf
{
    public string Value { get; }

    public Cpf(string value)
    {
        var digits = new string((value ?? string.Empty).Where(char.IsDigit).ToArray());
        if (!IsValid(digits))
        {
            throw new ArgumentException("CPF inválido.", nameof(value));
        }

        Value = digits;
    }

    private static bool IsValid(string cpf)
    {
        if (cpf.Length != 11)
        {
            return false;
        }

        if (cpf.All(c => c == cpf[0]))
        {
            return false;
        }

        var firstDigit = CalculateVerifier(cpf, 9, 10);
        var secondDigit = CalculateVerifier(cpf, 10, 11);

        return cpf[9] == firstDigit && cpf[10] == secondDigit;
    }

    private static char CalculateVerifier(string cpf, int length, int weightStart)
    {
        var sum = 0;
        for (var i = 0; i < length; i++)
        {
            sum += (cpf[i] - '0') * (weightStart - i);
        }

        var remainder = sum % 11;
        var digit = remainder < 2 ? 0 : 11 - remainder;
        return (char)('0' + digit);
    }

    public override string ToString() => Value;
}
