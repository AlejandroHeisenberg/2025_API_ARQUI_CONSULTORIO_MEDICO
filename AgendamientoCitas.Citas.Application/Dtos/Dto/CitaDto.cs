using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Application.Dtos.Dto
{
    public class CitaDto
    {
        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }

        public string Fecha { get; set; }

        public string Hora { get; set; }
    }
}
