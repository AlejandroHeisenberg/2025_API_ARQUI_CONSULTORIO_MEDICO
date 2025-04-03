using System;
using System.Collections.Generic;
using AgendamientoCitas.Pacientes.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoCitas.Pacientes.Infrastruture.Repositories.Contexto;

public partial class AgendamientoDbContext : DbContext
{
    public AgendamientoDbContext()
    {
    }

    public AgendamientoDbContext(DbContextOptions<AgendamientoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
