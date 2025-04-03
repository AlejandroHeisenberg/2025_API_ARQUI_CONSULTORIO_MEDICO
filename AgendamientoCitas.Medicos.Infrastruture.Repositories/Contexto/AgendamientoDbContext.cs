using System;
using System.Collections.Generic;
using AgendamientosCitas.Medicos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientosCitas.Medicos.Infrastruture.Repositories.Contexto;

public partial class AgendamientoDbContext : DbContext
{
    public AgendamientoDbContext()
    {
    }

    public AgendamientoDbContext(DbContextOptions<AgendamientoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agenda> Agendas { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.IdAgenda);

            entity.Property(e => e.Dias).HasMaxLength(255);
            entity.Property(e => e.Horas).HasMaxLength(255);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico);

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Especialidad).HasMaxLength(60);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(10);

            entity.HasOne(d => d.IdAgendaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdAgenda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Medicos_Agendas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
