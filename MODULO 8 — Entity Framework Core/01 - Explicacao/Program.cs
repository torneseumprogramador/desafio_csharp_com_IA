using _01___Explicacao.Context;
using Microsoft.EntityFrameworkCore;

var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING")
    ?? "server=localhost;port=3306;database=meubanco;user=root;password=;";

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

using var db = new AppDbContext(optionsBuilder.Options);
var clientes = db.Clientes
    .Include(c => c.Endereco)
    .OrderBy(c => c.Id)
    .ToList();

Console.WriteLine($"Provedor: {db.Database.ProviderName}");
Console.WriteLine();

const int idWidth = 4;
const int nomeWidth = 24;
const int telefoneWidth = 18;
const int enderecoWidth = 65;

var separator = $"+-{new string('-', idWidth)}-+-{new string('-', nomeWidth)}-+-{new string('-', telefoneWidth)}-+-{new string('-', enderecoWidth)}-+";
Console.WriteLine(separator);
Console.WriteLine(
    $"| {"ID".PadRight(idWidth)} | {"Nome".PadRight(nomeWidth)} | {"Telefone".PadRight(telefoneWidth)} | {"Endereco".PadRight(enderecoWidth)} |");
Console.WriteLine(separator);

foreach (var cliente in clientes)
{
    var endereco = cliente.Endereco is null
        ? "Endereco nao cadastrado"
        : $"{cliente.Endereco.Logradouro}, {cliente.Endereco.Numero}, {cliente.Endereco.Bairro}, {cliente.Endereco.Cidade}-{cliente.Endereco.Estado}, CEP {cliente.Endereco.Cep}";

    Console.WriteLine(
        $"| {cliente.Id.ToString().PadRight(idWidth)} | {cliente.Nome.PadRight(nomeWidth)} | {cliente.Telefone.PadRight(telefoneWidth)} | {endereco.PadRight(enderecoWidth)} |");
}

Console.WriteLine(separator);
