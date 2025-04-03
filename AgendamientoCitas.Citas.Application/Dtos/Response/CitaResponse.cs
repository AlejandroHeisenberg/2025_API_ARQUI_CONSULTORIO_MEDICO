using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Application.Dtos.Response
{
    public class CitaResponse
    {
        public int IdCitasMedica { get; set; }
        public string NombreMedico { get; set; }
        public string NombrePaciente {get; set;}
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}
