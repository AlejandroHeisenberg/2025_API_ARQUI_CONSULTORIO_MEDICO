using AgendamientoCitas.Pacientes.Application.Dtos.Dto;
using AgendamientoCitas.Pacientes.Application.Dtos.Response;
using AgendamientoCitas.Pacientes.Application.Interfaces;
using AgendamientoCitas.Pacientes.Domain.Entidades;
using AgendamientoCitas.Pacientes.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoCitas.Pacientes.Application.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PacienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pacienteDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddPacienteAsync(PacienteDto pacienteDto)
        {
            try
            {
                var paciente = new Paciente
                {
                    Nombre = pacienteDto.Nombre,
                    Apellidos = pacienteDto.Apellidos,
                    Direccion = pacienteDto.Direccion,
                    Email = pacienteDto.Email,
                    Telefono = pacienteDto.Telefono,
                    PlanSalud = pacienteDto.PlanSalud,
                };
                _unitOfWork.Crud<Paciente>().Add(paciente);
                var newPaciente = _unitOfWork.SaveChanges();

                return await Task.FromResult(newPaciente > 0);

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
        public Task<bool> DeletePacienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PacienteResponse> GetPacientePorIdAsync(int id)
        {
            try
            {
                PacienteResponse resultPaciente = new();
                var paciente = await _unitOfWork.Crud<Paciente>().Find(m => m.IdPaciente == id).FirstOrDefaultAsync();

                if (paciente != null)
                {
                    resultPaciente.IdPaciente = paciente.IdPaciente;
                    resultPaciente.Nombre = paciente.Nombre;
                    resultPaciente.Apellidos = paciente.Apellidos;
                    resultPaciente.Direccion = paciente.Direccion;
                    resultPaciente.Email = paciente.Email;
                    resultPaciente.Telefono = paciente.Telefono;
                    resultPaciente.PlanSalud = paciente.PlanSalud;
                }

                return resultPaciente;
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
        public async Task<IEnumerable<PacienteResponse>?> GetTodasLosPacienteAsync()
        {
            try
            {
                var paciente = _unitOfWork.Crud<Paciente>().GetAll();
                return paciente.Select(p => new PacienteResponse 
                { 
                  IdPaciente=p.IdPaciente,
                  Nombre = p.Nombre,
                  Apellidos = p.Apellidos,
                  Direccion = p.Direccion,
                  Email = p.Email,
                  Telefono = p.Telefono,
                  PlanSalud = p.PlanSalud,
                
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
        /// <param name="pacienteDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdatePacienteAsync(int id, PacienteDto pacienteDto)
        {
            try
            {
                var paciente = new Paciente
                {
                    IdPaciente = id,
                    Nombre = pacienteDto.Nombre,
                    Apellidos = pacienteDto.Apellidos,
                    Direccion = pacienteDto.Direccion,
                    Email = pacienteDto.Email,
                    Telefono = pacienteDto.Telefono,
                    PlanSalud = pacienteDto.PlanSalud,
                };

                _unitOfWork.Crud<Paciente>().Edit(paciente);
                var cambioPaciente = _unitOfWork.SaveChanges();

                return await Task.FromResult(cambioPaciente>0);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
