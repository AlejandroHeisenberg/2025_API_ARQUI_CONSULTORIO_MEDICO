using AgendamientosCitas.Citas.Application.Dtos.Dto;
using AgendamientosCitas.Citas.Application.Dtos.Response;
using AgendamientosCitas.Citas.Application.Interfasces;
using AgendamientosCitas.Citas.Domain.Entidades;
using AgendamientosCitas.Citas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Application.Service
{
    public class CitaService : ICitaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método para agregar una nueva cita (aún no implementado)
        /// </summary>
        /// <param name="citaDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddCitaAsync(CitaDto citaDto)
        {
            try
            {
                var cita = new Cita
                {
                    Fecha = DateOnly.Parse(citaDto.Fecha),
                    Hora = TimeOnly.Parse(citaDto.Hora),
                    IdPaciente = citaDto.IdPaciente,
                    IdMedico = citaDto.IdMedico,

                };
                _unitOfWork.Crud<Cita>().Add(cita);
                var AsignacionCita = _unitOfWork.SaveChanges();

                return await Task.FromResult(AsignacionCita > 0);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Método para eliminar una cita (aún no implementado)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteCitaAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para obtener una cita por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CitaResponse> GetCitaPorIdAsync(int id)
        {
            try
            {
                CitaResponse resultCita = new();
                var cita = await _unitOfWork.Crud<Cita>().Find(c => c.IdPaciente == id)
                    .Include(c => c.IdPacienteNavigation)
                    .Include(c => c.IdMedicoNavigation).FirstOrDefaultAsync();

                if (cita != null)
                {
                    resultCita.IdCitasMedica = cita.IdCitasMedica;
                    resultCita.NombrePaciente = cita.IdPacienteNavigation.Nombre;
                    resultCita.NombreMedico = cita.IdMedicoNavigation.Nombre;
                    resultCita.IdPaciente = cita.IdPaciente;
                    resultCita.IdMedico = cita.IdMedico;
                    resultCita.Fecha = cita.Fecha.ToDateTime(new TimeOnly(0, 0));
                    resultCita.Hora = cita.Hora.ToTimeSpan();

                }

                return resultCita;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }



        }

        /// <summary>
        /// Método para obtener todas las citas de un paciente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CitaResponse>?> GetCitaPorIdPacienteAsync(int id)
        {
            try
            {
                var citas = await _unitOfWork.Crud<Cita>().Find(c => c.IdPaciente == id).ToListAsync();
                if (citas != null && citas.Any())
                {
                    // Transformamos las entidades Cita a CitaResponse
                    var citaResponses = citas.Select(c => new CitaResponse
                    {
                        IdCitasMedica = c.IdCitasMedica,
                        IdPaciente = c.IdPaciente,
                        IdMedico = c.IdMedico,
                        Fecha = c.Fecha.ToDateTime(new TimeOnly(0, 0)),
                        Hora = c.Hora.ToTimeSpan()
                    }).ToList();

                    return citaResponses;
                }

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Método para obtener todas las citas (aún no implementado)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<CitaResponse>> GetTodasLasCitasAsync()
        {
            try
            {
                var citas = _unitOfWork.Crud<Cita>().GetAll();
                return citas.Select(m => new CitaResponse
                {
                   IdCitasMedica = m.IdCitasMedica,
                   NombreMedico = m.IdMedicoNavigation.Nombre,
                   NombrePaciente = m.IdPacienteNavigation.Nombre,
                   IdMedico = m.IdMedico,
                   IdPaciente=m.IdPaciente,
                   Fecha = m.Fecha.ToDateTime(new TimeOnly(0, 0)),
                   Hora = m.Hora.ToTimeSpan()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///  Método para actualizar una cita (aún no implementado)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="citaDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateCitaAsync(int id, CitaDto citaDto)
        {
            try
            {
                var cita = new Cita
                {
                    IdCitasMedica = id,
                    Fecha = DateOnly.Parse(citaDto.Fecha),
                    Hora = TimeOnly.Parse(citaDto.Hora),
                    IdPaciente = citaDto.IdPaciente,
                    IdMedico = citaDto.IdMedico,

                };
                _unitOfWork.Crud<Cita>().Edit(cita);
                var cambios = _unitOfWork.SaveChanges();

                return await Task.FromResult(cambios > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
