namespace Algoritimos.Usuarios;

class Menu
{
    public static void executar()
    {
        while (true)
        {
            var usuario = new Usuario();

            Console.WriteLine("Digite o nome do usuário: ");
            usuario.Nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
                continue;
            }

            Console.WriteLine($"Digite o email do(a) {usuario.Nome}: ");
            usuario.Email = Console.ReadLine() ?? "";

            Usuario.Adicionar(usuario);

            Console.WriteLine("Deseja cadastrar outro usuário? (s/n)");
            string? resposta = Console.ReadLine();
            if (resposta != null && resposta.Trim().ToLower() == "n")
            {
                break;
            }
        }

        Usuario.Mostrar();
    }
}