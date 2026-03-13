namespace Algoritimos.Tabuada;
class Tabuada
{
    // uma classe é um elemento que vc cria para orgnizar funçoes(pequenos algotitimos) ou propriedades (variáveis) em um arquivo
    public static void executar()
    {
        Console.WriteLine("Digite um número para gerar a tabuada: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int numero))
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
        }
    }
}