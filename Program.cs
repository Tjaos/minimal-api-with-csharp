using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options =>
{ 
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql") ?? string.Empty,
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql") ?? string.Empty)
    );
});

var app = builder.Build();

app.MapGet("/", () => "Olá, Mundo!");

app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login realizado com sucesso!");
    else
        return Results.Unauthorized();
});

app.Run();
