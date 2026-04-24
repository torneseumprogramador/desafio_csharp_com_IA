namespace _01___Explicacao.UI;

public static class InputHelper
{
    public static string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write(label);
            var value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("Valor obrigatorio. Tente novamente.");
        }
    }

    public static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (int.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }

            Console.WriteLine("Numero invalido. Tente novamente.");
        }
    }

    public static decimal ReadDecimal(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (decimal.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }

            Console.WriteLine("Valor invalido. Tente novamente.");
        }
    }

    public static bool ReadBool(string label)
    {
        while (true)
        {
            Console.Write(label);
            var input = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (input is "s" or "sim" or "y" or "yes" or "1")
            {
                return true;
            }

            if (input is "n" or "nao" or "não" or "0")
            {
                return false;
            }

            Console.WriteLine("Digite s/sim ou n/nao.");
        }
    }
}
