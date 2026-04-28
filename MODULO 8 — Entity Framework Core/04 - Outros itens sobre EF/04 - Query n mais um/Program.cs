using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<LojaContext>()
    .UseSqlite("Data Source=loja.db")
    .EnableSensitiveDataLogging()
    .Options;

using (var setup = new LojaContext(options))
{
    setup.Database.EnsureDeleted();
    setup.Database.EnsureCreated();
    Seed(setup);
}

using var context = new LojaContext(options);

Console.WriteLine("=== EXEMPLO ERRADO (N+1) ===");
var pedidos = context.Pedidos.AsNoTracking().ToList();
foreach (var pedido in pedidos)
{
    // ERRO: para cada pedido, executa uma nova query no banco.
    var quantidadeItens = context.ItensPedido.Count(i => i.PedidoId == pedido.Id);
    Console.WriteLine($"Pedido {pedido.Id} - Cliente: {pedido.Cliente} - Itens: {quantidadeItens}");
}

Console.WriteLine();
Console.WriteLine("=== EXEMPLO CORRETO (UMA QUERY COM LEFT JOIN) ===");
var pedidosComItens = context.Pedidos
    .AsNoTracking()
    .Include(p => p.Itens)
    .ToList();

foreach (var pedido in pedidosComItens)
{
    Console.WriteLine($"Pedido {pedido.Id} - Cliente: {pedido.Cliente} - Itens: {pedido.Itens.Count}");
}

static void Seed(LojaContext context)
{
    if (context.Pedidos.Any())
    {
        return;
    }

    var pedidos = new List<Pedido>
    {
        new()
        {
            Cliente = "Ana",
            Itens =
            {
                new ItemPedido { Produto = "Notebook", Quantidade = 1 },
                new ItemPedido { Produto = "Mouse", Quantidade = 2 }
            }
        },
        new()
        {
            Cliente = "Bruno",
            Itens =
            {
                new ItemPedido { Produto = "Teclado", Quantidade = 1 }
            }
        },
        new()
        {
            Cliente = "Carla",
            Itens =
            {
                new ItemPedido { Produto = "Monitor", Quantidade = 2 },
                new ItemPedido { Produto = "Cabo HDMI", Quantidade = 2 },
                new ItemPedido { Produto = "Suporte", Quantidade = 1 }
            }
        }
    };

    context.Pedidos.AddRange(pedidos);
    context.SaveChanges();
}

public sealed class LojaContext(DbContextOptions<LojaContext> options) : DbContext(options)
{
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Cliente).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Produto).HasMaxLength(100).IsRequired();

            entity.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId);
        });
    }
}

public sealed class Pedido
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public List<ItemPedido> Itens { get; set; } = [];
}

public sealed class ItemPedido
{
    public int Id { get; set; }
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }

    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
}
