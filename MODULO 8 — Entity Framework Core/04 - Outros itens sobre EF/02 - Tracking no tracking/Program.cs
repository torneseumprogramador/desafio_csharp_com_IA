using Microsoft.EntityFrameworkCore;

Console.WriteLine("=== Tracking x No Tracking (EF Core + SQLite) ===");

var dbPath = Path.Combine(AppContext.BaseDirectory, "tracking-demo.db");
await using var context = new VendasContext(dbPath);

await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

if (!await context.Produtos.AnyAsync())
{
    context.Produtos.Add(new Produto { Nome = "Teclado Mecânico", Preco = 250m });
    await context.SaveChangesAsync();
}

Console.WriteLine("\n1) CONSULTA COM TRACKING (padrão)");
var produtoComTracking = await context.Produtos.FirstAsync();

Console.WriteLine($"Preço antes da alteração: {produtoComTracking.Preco:C}");
produtoComTracking.Preco += 50m;
await context.SaveChangesAsync();

var valorPersistidoTracking = await context.Produtos
    .AsNoTracking()
    .Select(p => p.Preco)
    .FirstAsync();

Console.WriteLine($"Preço depois do SaveChanges (tracking): {valorPersistidoTracking:C}");
Console.WriteLine("Resultado: O EF detectou a mudança automaticamente e atualizou no banco.");

Console.WriteLine("\n2) CONSULTA COM NO TRACKING");
var produtoNoTracking = await context.Produtos
    .AsNoTracking()
    .FirstAsync();

Console.WriteLine($"Preço antes da alteração: {produtoNoTracking.Preco:C}");
produtoNoTracking.Preco += 100m;
await context.SaveChangesAsync();

var valorPersistidoNoTracking = await context.Produtos
    .AsNoTracking()
    .Select(p => p.Preco)
    .FirstAsync();

Console.WriteLine($"Preço depois do SaveChanges (no tracking): {valorPersistidoNoTracking:C}");
Console.WriteLine("Resultado: Nada mudou no banco, porque o objeto não estava sendo rastreado.");

Console.WriteLine("\n3) COMO SALVAR UM OBJETO LIDO COM NO TRACKING");
context.ChangeTracker.Clear();
context.Produtos.Update(produtoNoTracking);
await context.SaveChangesAsync();

var valorAposUpdate = await context.Produtos
    .AsNoTracking()
    .Select(p => p.Preco)
    .FirstAsync();

Console.WriteLine($"Preço depois de Update + SaveChanges: {valorAposUpdate:C}");
Console.WriteLine("Resultado: Ao anexar a entidade ao contexto (Update), a alteração é persistida.");

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}

public class VendasContext(string dbPath) : DbContext
{
    public DbSet<Produto> Produtos => Set<Produto>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
