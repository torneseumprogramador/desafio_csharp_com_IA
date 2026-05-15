using Ecommerce.ConsoleApp.Application;
using Ecommerce.ConsoleApp.CompositionRoot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var services = new ServiceCollection();
services.AddEcommerceConsole(configuration);

using var provider = services.BuildServiceProvider();
using var scope = provider.CreateScope();

var app = scope.ServiceProvider.GetRequiredService<ConsoleAppRunner>();
await app.RunAsync();
