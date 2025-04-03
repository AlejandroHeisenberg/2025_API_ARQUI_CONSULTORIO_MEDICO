using AgendamientosCitas.Citas.Application.Interfasces;
using AgendamientosCitas.Citas.Application.Service;
using AgendamientosCitas.Citas.Domain.Interfaces;
using AgendamientosCitas.Citas.Infrastructure.Repositories.Contexto;
using AgendamientosCitas.Citas.Infrastructure.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgendamientoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgendamientoCitasDB")));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICitaService, CitaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
