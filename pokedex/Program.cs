using pokedex.Models;
using pokedex.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDBSettings to the DI container
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Add services to the container
builder.Services.AddScoped<IPokemonService, PokemonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
