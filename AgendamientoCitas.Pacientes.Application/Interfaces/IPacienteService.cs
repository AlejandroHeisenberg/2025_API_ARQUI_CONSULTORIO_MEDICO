using AgendamientoCitas.Pacientes.Application.Dtos.Dto;
using AgendamientoCitas.Pacientes.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientoCitas.Pacientes.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<PacienteResponse> GetPacientePorIdAsync(int id);
        Task<IEnumerable<PacienteResponse>?> GetTodasLosPacienteAsync();
        Task<bool> AddPacienteAsync(PacienteDto pacienteDto);
        Task<bool> UpdatePacienteAsync(int id, PacienteDto pacienteDto);
        Task<bool> DeletePacienteAsync(int id);
    }
}
