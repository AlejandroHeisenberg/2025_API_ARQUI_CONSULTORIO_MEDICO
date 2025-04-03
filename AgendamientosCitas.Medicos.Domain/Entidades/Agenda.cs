using System;
using System.Collections.Generic;

namespace AgendamientosCitas.Medicos.Domain.Entidades;

public partial class Agenda
{
    public int IdAgenda { get; set; }

    public string Dias { get; set; } = null!;

    public string Horas { get; set; } = null!;

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
