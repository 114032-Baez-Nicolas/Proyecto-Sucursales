using _114032_Báez_Nicolás_Final_Prog_III.Models;
using _114032_Báez_Nicolás_Final_Prog_III.Repositories.Implementaciones;
using _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;
using _114032_Báez_Nicolás_Final_Prog_III.Services.Implementaciones;
using _114032_Báez_Nicolás_Final_Prog_III.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//(1) Inyección de dependencias
builder.Services.AddScoped<IExtraRepository, ExtraRepository>();
builder.Services.AddScoped<ISucursalesRepository, SucursalesRepository>();
builder.Services.AddScoped<IParcialService, ParcialService>();

//(2) Conexión con la Base de datos
builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//(3) Validaciones de campos obligatorios (Fluent Validation)
builder.Services.AddFluentValidation((options) =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

//(4) Mapeador de objetos (AutoMapper)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//(5) Base Response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//(6) Uso compartido de recursos (Cors)
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
