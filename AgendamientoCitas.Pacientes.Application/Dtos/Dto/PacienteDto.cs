using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientoCitas.Pacientes.Application.Dtos.Dto
{
    public class PacienteDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public bool PlanSalud { get; set; }
    }
}
