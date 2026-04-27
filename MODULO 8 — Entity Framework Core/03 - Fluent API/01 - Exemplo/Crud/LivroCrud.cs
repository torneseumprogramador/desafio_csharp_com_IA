using _01___Exemplo.Data;
using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Crud;

public static class LivroCrud
{
    public static int Criar(BibliotecaContext context, int autorId)
    {
        var livro = new Livro
        {
            Titulo = "Dom Casmurro",
            Isbn = "978-85-359-0277-5",
            AnoPublicacao = 1899,
            QuantidadeDisponivel = 3,
            AutorId = autorId
        };

        context.Livros.Add(livro);
        context.SaveChanges();
        Console.WriteLine($"[CREATE] Livro criado: {livro.Titulo} (Id: {livro.Id})");
        return livro.Id;
    }

    public static void Ler(BibliotecaContext context)
    {
        var livros = context.Livros
            .Include(l => l.Autor)
            .AsNoTracking()
            .ToList();

        Console.WriteLine("[READ] Livros:");
        foreach (var livro in livros)
        {
            Console.WriteLine($"- {livro.Id} | {livro.Titulo} | Autor: {livro.Autor.Nome} | Estoque: {livro.QuantidadeDisponivel}");
        }
        Console.WriteLine();
    }

    public static void Atualizar(BibliotecaContext context, int livroId)
    {
        var livro = context.Livros.First(l => l.Id == livroId);
        livro.QuantidadeDisponivel = 2;
        context.SaveChanges();
        Console.WriteLine($"[UPDATE] Livro {livro.Id} atualizado.");
    }

    public static void Excluir(BibliotecaContext context, int livroId)
    {
        var livro = context.Livros.First(l => l.Id == livroId);
        context.Livros.Remove(livro);
        context.SaveChanges();
        Console.WriteLine($"[DELETE] Livro {livro.Id} removido.");
    }
}
