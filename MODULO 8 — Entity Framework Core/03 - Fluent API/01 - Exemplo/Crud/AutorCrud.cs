using _01___Exemplo.Data;
using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Crud;

public static class AutorCrud
{
    public static int Criar(BibliotecaContext context)
    {
        var autor = new Autor
        {
            Nome = "Machado de Assis",
            Nacionalidade = "Brasileiro"
        };

        context.Autores.Add(autor);
        context.SaveChanges();
        Console.WriteLine($"[CREATE] Autor criado: {autor.Nome} (Id: {autor.Id})");
        return autor.Id;
    }

    public static void Ler(BibliotecaContext context)
    {
        var autores = context.Autores.AsNoTracking().ToList();
        Console.WriteLine("[READ] Autores:");
        foreach (var autor in autores)
        {
            Console.WriteLine($"- {autor.Id} | {autor.Nome} | {autor.Nacionalidade}");
        }
        Console.WriteLine();
    }

    public static void Atualizar(BibliotecaContext context, int autorId)
    {
        var autor = context.Autores.First(a => a.Id == autorId);
        autor.Nacionalidade = "Brasileiro (RJ)";
        context.SaveChanges();
        Console.WriteLine($"[UPDATE] Autor {autor.Id} atualizado.");
    }

    public static void Excluir(BibliotecaContext context, int autorId)
    {
        var autor = context.Autores.First(a => a.Id == autorId);
        context.Autores.Remove(autor);
        context.SaveChanges();
        Console.WriteLine($"[DELETE] Autor {autor.Id} removido.");
    }
}
