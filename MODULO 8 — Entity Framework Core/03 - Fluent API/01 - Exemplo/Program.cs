using _01___Exemplo.Data;
using _01___Exemplo.Crud;
using _01___Exemplo.Querys;

using var context = new BibliotecaContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Console.WriteLine("=== CRUD BIBLIOTECA COM FLUENT API ===");
Console.WriteLine();

var autorId = AutorCrud.Criar(context);
AutorCrud.Ler(context);
AutorCrud.Atualizar(context, autorId);
AutorCrud.Ler(context);

var livroId = LivroCrud.Criar(context, autorId);
LivroCrud.Ler(context);
LivroCrud.Atualizar(context, livroId);
LivroCrud.Ler(context);

var usuarioId = UsuarioCrud.Criar(context);
UsuarioCrud.Ler(context);
UsuarioCrud.Atualizar(context, usuarioId);
UsuarioCrud.Ler(context);

var emprestimoId = EmprestimoCrud.Criar(context, livroId, usuarioId);
EmprestimoCrud.Ler(context);
EmprestimoCrud.Atualizar(context, emprestimoId, livroId);
EmprestimoCrud.Ler(context);

LinqQueries.Executar(context);
LinqToSqlQueries.Executar(context);
RawSqlQueries.Executar(context);

EmprestimoCrud.Excluir(context, emprestimoId);
LivroCrud.Excluir(context, livroId);
UsuarioCrud.Excluir(context, usuarioId);
AutorCrud.Excluir(context, autorId);

Console.WriteLine("Registros removidos para demonstrar o DELETE.");
