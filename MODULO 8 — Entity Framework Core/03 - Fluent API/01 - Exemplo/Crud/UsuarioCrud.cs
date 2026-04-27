using _01___Exemplo.Data;
using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Crud;

public static class UsuarioCrud
{
    public static int Criar(BibliotecaContext context)
    {
        var usuario = new Usuario
        {
            Nome = "Danilo Oliveira",
            Email = "danilo@email.com",
            DataCadastro = DateTime.UtcNow
        };

        context.Usuarios.Add(usuario);
        context.SaveChanges();
        Console.WriteLine($"[CREATE] Usuario criado: {usuario.Nome} (Id: {usuario.Id})");
        return usuario.Id;
    }

    public static void Ler(BibliotecaContext context)
    {
        var usuarios = context.Usuarios.AsNoTracking().ToList();
        Console.WriteLine("[READ] Usuarios:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"- {usuario.Id} | {usuario.Nome} | {usuario.Email}");
        }
        Console.WriteLine();
    }

    public static void Atualizar(BibliotecaContext context, int usuarioId)
    {
        var usuario = context.Usuarios.First(u => u.Id == usuarioId);
        usuario.Email = "danilo.oliveira@email.com";
        context.SaveChanges();
        Console.WriteLine($"[UPDATE] Usuario {usuario.Id} atualizado.");
    }

    public static void Excluir(BibliotecaContext context, int usuarioId)
    {
        var usuario = context.Usuarios.First(u => u.Id == usuarioId);
        context.Usuarios.Remove(usuario);
        context.SaveChanges();
        Console.WriteLine($"[DELETE] Usuario {usuario.Id} removido.");
    }
}
