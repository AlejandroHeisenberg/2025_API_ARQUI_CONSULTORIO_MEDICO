using AgendamientoCitas.Medicos.Application.Interfaces;
using AgendamientoCitas.Medicos.Application.Services;
using AgendamientosCitas.Medicos.Domain.Interfaces;
using AgendamientosCitas.Medicos.Infrastruture.Repositories.Contexto;
using AgendamientosCitas.Medicos.Infrastruture.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgendamientoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgendamientoCitasDB")));
// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMedicosService, MedicosService>();

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
