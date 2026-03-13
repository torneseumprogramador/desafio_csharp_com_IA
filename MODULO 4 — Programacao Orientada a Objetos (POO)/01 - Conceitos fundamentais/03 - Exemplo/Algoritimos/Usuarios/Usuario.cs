namespace Algoritimos.Usuarios;

class Usuario
{
    public Usuario(){ }

    public Usuario(string? nome, string? email)
    {
        Nome = nome;
        Email = email;
    }

    public string? Nome { get; set; }
    public string? Email { get; set; }

    private static List<Usuario> _usuarios = new List<Usuario>();

    public static void Adicionar(Usuario usuario)
    {
        _usuarios.Add(usuario);
    }

    public static List<Usuario> Listar()
    {
        return _usuarios;
    }

    public static void Mostrar()
    {
        const int nomeWidth = 20;
        const int emailWidth = 30;

        string header = $"| {"Nome".PadRight(nomeWidth)} | {"Email".PadRight(emailWidth)} |";
        string separator = new string('-', header.Length);

        Console.WriteLine(separator);
        Console.WriteLine(header);
        Console.WriteLine(separator);

        foreach (Usuario usuario in _usuarios)
        {
            string nome = (usuario.Nome ?? "").PadRight(nomeWidth);
            string email = (usuario.Email ?? "").PadRight(emailWidth);
            Console.WriteLine($"| {nome} | {email} |");
        }

        Console.WriteLine(separator);
    }
}

// var usuario = new Usuario()
// usuario.Nome = "João";
// usuario.Email = "joao@example.com";

// var usuario2 = new Usuario()
// usuario2.Nome = "Maria";
// usuario2.Email = "maria@example.com";

// var usuarioTuple  (string nome, string email)
// usuarioTuple.nome = "João";
// usuarioTuple.email = "joao@example.com";

// var usuarioDynamic = new { Nome = "João", Email = "joao@example.com" };
// usuarioDynamic.Nome = "João";
// usuarioDynamic.Email = "joao@example.com";