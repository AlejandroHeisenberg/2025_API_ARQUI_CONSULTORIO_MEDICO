using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientoCitas.Medicos.Application.Dtos.Dto
{
    public class MedicoDto
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
    }
}
