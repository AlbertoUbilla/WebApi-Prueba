using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.Datos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opcion => opcion.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<AplicationDbContext>(opcion => opcion.UseSqlServer("Name=ConexionDB"));

var app = builder.Build();

app.MapControllers();

app.Run();
