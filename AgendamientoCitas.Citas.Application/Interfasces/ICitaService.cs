using AgendamientosCitas.Citas.Application.Dtos.Dto;
using AgendamientosCitas.Citas.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Application.Interfasces
{
    public interface ICitaService
    {
        Task<CitaResponse> GetCitaPorIdAsync(int id);
        Task<IEnumerable<CitaResponse>?> GetCitaPorIdPacienteAsync(int id);
        Task<IEnumerable<CitaResponse>> GetTodasLasCitasAsync();
        Task<bool> AddCitaAsync(CitaDto citaDto);
        Task<bool> UpdateCitaAsync(int id, CitaDto citaDto);
        Task<bool> DeleteCitaAsync(int id);
    }
}
