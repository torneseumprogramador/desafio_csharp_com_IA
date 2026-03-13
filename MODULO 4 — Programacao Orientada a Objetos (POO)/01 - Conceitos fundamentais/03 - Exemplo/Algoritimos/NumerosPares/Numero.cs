namespace Algoritimos.NumerosPares;

class Numero
{
    public static void executar()
    {
        Console.WriteLine("Digite um número: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int numero))
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine("O número é par");
            }
            else
            {
                Console.WriteLine("O número é ímpar");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
        }
    }
}