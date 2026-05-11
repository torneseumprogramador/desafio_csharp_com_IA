using primeiraApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectDependencies(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
}).AddXmlSerializerFormatters();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
