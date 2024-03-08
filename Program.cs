using JwtBearer.Models;
using JwtBearer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();

var app = builder.Build();


app.MapGet("/", (TokenService service) => service.Generate(
    new User(1,
    "teste@gmail.com",
    "123",
    new[]
    {
        "student","premium"
    })));

app.Run();
