using ProyectoCore.Repositories.Interfaces;
using ProyectoCore.Repositories.RepoClase;
using ProyectoCore.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=localhost;Database=gran_et12;Uid=grandt_user;Pwd=grandt_pass;";

// Registrar DBConnection
builder.Services.AddSingleton(new DBConnection(connectionString));

// Registrar Repositorios
builder.Services.AddScoped<IRepoPosicion, RepoPosicion>();
builder.Services.AddScoped<IRepoEquipo, RepoEquipo>();
builder.Services.AddScoped<IRepoJugador, RepoJugador>();
builder.Services.AddScoped<IRepoUsuario, RepoUsuario>();
builder.Services.AddScoped<IRepoPlantilla, RepoPlantilla>();
builder.Services.AddScoped<IRepoPlantillaTitular, RepoPlantillaTitular>();
builder.Services.AddScoped<IRepoPlantillaSuplente, RepoPlantillaSuplente>();
builder.Services.AddScoped<IRepoPuntuacion, RepoPuntuacion>();

// Registrar Servicios
builder.Services.AddScoped<ServicePosicion>();
builder.Services.AddScoped<ServiceEquipo>();
builder.Services.AddScoped<ServiceJugador>();
builder.Services.AddScoped<ServiceUsuario>();
builder.Services.AddScoped<ServicePlantilla>();
builder.Services.AddScoped<ServicePlantillaTitular>();
builder.Services.AddScoped<ServicePlantillaSuplente>();
builder.Services.AddScoped<ServicePuntuacion>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => { c.RouteTemplate = "openapi/{documentName}.json"; });
    app.MapScalarApiReference();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
