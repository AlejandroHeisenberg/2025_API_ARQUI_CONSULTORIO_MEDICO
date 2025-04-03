using System;
using System.Collections.Generic;

namespace AgendamientosCitas.Citas.Domain.Entidades;

public partial class Cita
{
    public int IdCitasMedica { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
