﻿using System;
using System.Collections.Generic;

namespace AgendamientosCitas.Citas.Domain.Entidades;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public bool PlanSalud { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
