using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// Configuração do logger para mostrar os selects/executados no console
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
        .AddConsole();
});

using (var setupContext = new BibliotecaContext(loggerFactory))
{
    setupContext.Database.EnsureDeleted();
    setupContext.Database.EnsureCreated();

    if (setupContext.Autores.Any())
    {
        return;
    }

    var autores = new List<Autor>
    {
        new()
        {
            Nome = "J. R. R. Tolkien",
            Livros = new List<Livro>
            {
                new() { Titulo = "O Hobbit" },
                new() { Titulo = "O Senhor dos Aneis" }
            }
        },
        new()
        {
            Nome = "George Orwell",
            Livros = new List<Livro>
            {
                new() { Titulo = "1984" },
                new() { Titulo = "A Revolucao dos Bichos" }
            }
        }
    };

    setupContext.Autores.AddRange(autores);
    setupContext.SaveChanges();
}

Console.WriteLine("==============================================================");

using var context = new BibliotecaContext(loggerFactory);

Console.WriteLine("=== EXEMPLO: LAZY LOADING ===");
Console.WriteLine("Consulta inicial sem Include. Livros serao carregados sob demanda.");
Console.WriteLine();

var autoresLazy = context.Autores.ToList();

foreach (var autor in autoresLazy)
{
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Autor: {autor.Nome}");

    // Se o objetivo é mostrar somenmte a quantidade de livros utilizar o codigo abaixo
    Console.WriteLine(
        $"Quantidade com COUNT(*) direto no banco: {context.Livros.Count(l => l.AutorId == autor.Id)}");

    // Aqui o proxy lazy dispara um SELECT em Livros para esse autor, fazendo com que ele carregue os livros, utilize o abaixo.
    Console.WriteLine($"Quantidade de livros (lazy): {autor.Livros.Count}");
    foreach (var livro in autor.Livros)
    {
        Console.WriteLine($"- {livro.Titulo}");
    }

    Console.WriteLine();
}






Console.WriteLine("==============================================================");
Console.WriteLine("=== EXEMPLO: EAGER LOADING ===");
Console.WriteLine("Consulta com Include. Livros sao trazidos junto na mesma consulta.");
Console.WriteLine();

var autoresEager = context.Autores
    .Include(a => a.Livros)
    .ToList();


foreach (var autor in autoresEager)
{
    Console.WriteLine($"Autor: {autor.Nome}");

    Console.WriteLine($"Quantidade de livros (eager): {autor.Livros.Count}");

    foreach (var livro in autor.Livros)
    {
        Console.WriteLine($"- {livro.Titulo}");
    }

    Console.WriteLine();
}

public class BibliotecaContext : DbContext
{
    private readonly ILoggerFactory? _loggerFactory;

    // Sobrecarga para permitir injeção de logger
    public BibliotecaContext() { }
    public BibliotecaContext(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Livro> Livros => Set<Livro>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=biblioteca-lazy-eager.db");
        }

        // Adiciona logger se fornecido
        if (_loggerFactory != null)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Nome).HasMaxLength(120).IsRequired();

            entity.HasMany(a => a.Livros)
                .WithOne(l => l.Autor)
                .HasForeignKey(l => l.AutorId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Titulo).HasMaxLength(200).IsRequired();
        });
    }
}

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;

    public int AutorId { get; set; }
    public virtual Autor Autor { get; set; } = null!;
}
