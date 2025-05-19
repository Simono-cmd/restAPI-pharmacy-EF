using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Konfiguracja kontekstu bazy danych
// ConnectionString jest pobierany z appsettings.json, oczywiście należy go tam też ustawić
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Wstrzykiwanie zależności
// https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();