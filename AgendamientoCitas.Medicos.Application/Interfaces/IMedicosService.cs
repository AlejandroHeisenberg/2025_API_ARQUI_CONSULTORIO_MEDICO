using AgendamientoCitas.Medicos.Application.Dtos.Dto;
using AgendamientoCitas.Medicos.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientoCitas.Medicos.Application.Interfaces
{
    public interface IMedicosService
    {
        Task<MedicoReponse> GetMedicoPorIdAsync(int id);    
        Task<IEnumerable<MedicoReponse>> GetTodasLosMedicosAsync();
        Task<bool> AddMedicossync(MedicoDto citaDto);
        Task<bool> UpdateMedicoAsync(int id, MedicoDto citaDto);
        Task<bool> DeleteMedicoAsync(int id);
    }
}
