using System;
using System.Collections.Generic;

namespace AgendamientosCitas.Medicos.Domain.Entidades;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public bool Especialista { get; set; }

    public string Especialidad { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdAgenda { get; set; }

    public virtual Agenda? IdAgendaNavigation { get; set; }
}
