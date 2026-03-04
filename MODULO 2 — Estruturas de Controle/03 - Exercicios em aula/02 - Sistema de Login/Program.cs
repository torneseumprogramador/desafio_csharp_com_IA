for (int i = 1; i <= 3; i++)
{
    Console.WriteLine("Digite o usuário: ");
    string usuario = Console.ReadLine() ?? "";
    Console.WriteLine("Digite a senha: ");
    string senha = Console.ReadLine() ?? "";
    if (usuario == "admin" && senha == "1234")
    {
        Console.Clear();
        Console.WriteLine("Login realizado com sucesso!");
        System.Threading.Thread.Sleep(3000);
        break;
    }
    else
    {
        Console.Clear();
        if(usuario != "admin")
        {
            Console.WriteLine("Usuário não encontrado");
        }
        else if(senha != "1234")
        {
            Console.WriteLine("Senha incorreta");
        }
        
        System.Threading.Thread.Sleep(2000);
        Console.Clear();

        if(3 - i == 0)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Acesso bloqueado.");
            break;
        }

        Console.WriteLine($"Tentativas restantes: {3 - i}");
        System.Threading.Thread.Sleep(3000);
        Console.Clear();
    }
}