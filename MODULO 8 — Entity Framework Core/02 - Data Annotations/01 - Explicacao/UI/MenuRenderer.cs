namespace _01___Explicacao.UI;

public static class MenuRenderer
{
    public static void ShowHeader(string title)
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine(title);
        Console.WriteLine("==============================================");
    }

    public static void Pause()
    {
        Console.WriteLine();
        Console.Write("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}
