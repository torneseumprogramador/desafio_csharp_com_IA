using _01___Exemplo.Data;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Querys;

public static class LinqToSqlQueries
{
    public static void Executar(BibliotecaContext context)
    {
        Console.WriteLine("=== CONSULTAS ESTILO LINQ TO SQL ===");
        Console.WriteLine("No EF Core usamos LINQ to Entities, que segue a mesma ideia de traducao para SQL.");

        var consultaComJoin =
            (from e in context.Emprestimos.AsNoTracking()
             join u in context.Usuarios.AsNoTracking() on e.UsuarioId equals u.Id
             join l in context.Livros.AsNoTracking() on e.LivroId equals l.Id
             join a in context.Autores.AsNoTracking() on l.AutorId equals a.Id
             select new
             {
                 EmprestimoId = e.Id,
                 Usuario = u.Nome,
                 Livro = l.Titulo,
                 Autor = a.Nome,
                 e.Status
             }).ToList();

        Console.WriteLine("[QUERY SYNTAX - JOIN]");
        foreach (var item in consultaComJoin)
        {
            Console.WriteLine($"- Emprestimo: {item.EmprestimoId} | Usuario: {item.Usuario} | Livro: {item.Livro} | Autor: {item.Autor} | Status: {item.Status}");
        }

        var groupByAutor =
            (from l in context.Livros.AsNoTracking()
             join a in context.Autores.AsNoTracking() on l.AutorId equals a.Id
             group l by a.Nome into g
             select new
             {
                 Autor = g.Key,
                 TotalLivros = g.Count()
             }).ToList();

        Console.WriteLine("[QUERY SYNTAX - GROUP BY AUTOR]");
        foreach (var item in groupByAutor)
        {
            Console.WriteLine($"- Autor: {item.Autor} | Quantidade de Livros: {item.TotalLivros}");
        }

        Console.WriteLine();
    }
}
