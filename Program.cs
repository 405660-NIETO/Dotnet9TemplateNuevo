using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Programacion3Template.Data;
using Programacion3Template.Interfaces;
using Programacion3Template.Repositories;
using Programacion3Template.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar siempre los scopeds despues del context.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Programacion3Template API",
        Version = "v1",
        Description = "API para el examen de Programación 3",
        Contact = new OpenApiContact
        {
            Name = "Agus",
            Email = "agus@example.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Programacion3Template API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
