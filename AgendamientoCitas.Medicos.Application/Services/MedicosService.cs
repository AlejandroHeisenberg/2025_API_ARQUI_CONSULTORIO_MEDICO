using AgendamientoCitas.Medicos.Application.Dtos.Dto;
using AgendamientoCitas.Medicos.Application.Dtos.Response;
using AgendamientoCitas.Medicos.Application.Interfaces;
using AgendamientosCitas.Medicos.Domain.Entidades;
using AgendamientosCitas.Medicos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AgendamientoCitas.Medicos.Application.Services
{
    public class MedicosService : IMedicosService
    {

        private readonly IUnitOfWork _unitOfWork;

        public MedicosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="citaDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddMedicossync(MedicoDto citaDto)
        {
            try
            {
                var medico = new Medico
                {
                    Nombre = citaDto.Nombre,
                    Apellido = citaDto.Apellido,
                    Especialista = citaDto.Especialista,
                    Especialidad = citaDto.Especialidad,
                    Telefono = citaDto.Telefono,
                    Direccion = citaDto.Direccion,
                    Email = citaDto.Email,
                    IdAgenda = citaDto.IdAgenda,
                };

                _unitOfWork.Crud<Medico>().Add(medico);
                var newMedico = _unitOfWork.SaveChanges();

                return await Task.FromResult(newMedico > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteMedicoAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MedicoReponse> GetMedicoPorIdAsync(int id)
        {
            try
            {
                MedicoReponse resultMedico = new();
                var medico = await _unitOfWork.Crud<Medico>().Find(m =>m.IdMedico == id)
                            .Include(m => m.IdAgendaNavigation).FirstOrDefaultAsync();
                if (medico != null)
                {
                    resultMedico.IdMedico = medico.IdMedico;
                    resultMedico.Nombre = medico.Nombre;
                    resultMedico.Apellido = medico.Apellido;
                    resultMedico.Especialista = medico.Especialista;
                    resultMedico.Especialidad = medico.Especialidad;
                    resultMedico.Telefono = medico.Telefono;
                    resultMedico.Direccion = medico.Direccion;
                    resultMedico.Email = medico.Email;
                    resultMedico.IdAgenda = medico.IdAgenda;
                }

                return resultMedico;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<MedicoReponse>> GetTodasLosMedicosAsync()
        {
            try
            {
                var medicos = _unitOfWork.Crud<Medico>().GetAll();
                return medicos.Select(m => new MedicoReponse
                {
                    IdMedico = m.IdMedico,
                    Nombre = m.Nombre,
                    Apellido = m.Apellido,
                    Especialista = m.Especialista,
                    Especialidad = m.Especialidad,
                    Telefono = m.Telefono,
                    Direccion = m.Direccion,
                    Email = m.Email,
                    IdAgenda = m.IdAgenda,
                }).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
           
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="citaDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateMedicoAsync(int id, MedicoDto citaDto)
        {
            try
            {
                var medico = new Medico
                {
                    Nombre = citaDto.Nombre,
                    Apellido = citaDto.Apellido,
                    Especialista = citaDto.Especialista,
                    Especialidad = citaDto.Especialidad,
                    Telefono = citaDto.Telefono,
                    Direccion = citaDto.Direccion,
                    Email = citaDto.Email,
                    IdAgenda = citaDto.IdAgenda,
                };

                _unitOfWork.Crud<Medico>().Edit(medico);
                var cambioMedico = _unitOfWork.SaveChanges();

                return await Task.FromResult(cambioMedico > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
