while (true)
{
    Console.WriteLine("Digite um número inteiro para ver a tabuada: ");
    int numero = 0;
    if (int.TryParse(Console.ReadLine() ?? "0", out numero))
    {
        if (numero < 1 || numero > 10)
        {
            Console.WriteLine("Numero inválido, tente novamente (1-10)");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            continue;
        }

        Console.Clear();
        
        Console.WriteLine($"Tabuada do {numero}");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
        break;
    }
     
    Console.WriteLine("Numero inválido, tente novamente");
    System.Threading.Thread.Sleep(3000);
    Console.Clear();
}
