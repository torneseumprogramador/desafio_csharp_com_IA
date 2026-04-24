using _01___Explicacao.Context;
using _01___Explicacao.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("app.json", optional: false)
    .Build();

var connectionString = configuration.GetConnectionString("MySql")
    ?? throw new InvalidOperationException("ConnectionStrings:MySql nao encontrada no app.json.");

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

using var db = new AppDbContext(optionsBuilder.Options);
var appMenu = new AppMenu(db);
appMenu.Run();
