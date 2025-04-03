using AgendamientoCitas.Medicos.Application.Interfaces;
using AgendamientoCitas.Medicos.Application.Services;
using AgendamientoCitas.Pacientes.Application.Dtos.Dto;
using AgendamientoCitas.Pacientes.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoCitas.Pacientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        /// <summary>
        /// Acción para obtener todas las citas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPacientes()
        {
            var paciente = await _pacienteService.GetTodasLosPacienteAsync();
            if (paciente == null) 
                return NotFound(new { mensaje = "No se encontro ningun paciente"});
            
            return Ok(paciente);
        }

        /// <summary>
        /// Acción para obtener una cita específica por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacientesId(int id)
        {
            var paciente = await _pacienteService.GetPacientePorIdAsync(id);
            if (paciente == null)
                return NotFound( new { mensaje = "Paciente no encontrado"});

            return Ok(paciente);
        }

        /// <summary>
        /// Acción para agregar una nueva cita
        /// </summary>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPacientes(PacienteDto paciente)
        {
            var newPaciente = await _pacienteService.AddPacienteAsync(paciente);
            if (!newPaciente)
                return NotFound(new { mensaje = "Paciente no creado" });
          

            return Ok("Paciente Creado");
        }

        /// <summary>
        /// Acción para actualizar una cita existente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePacientes(int id, PacienteDto paciente)
        {
            var editPaciente = await _pacienteService.UpdatePacienteAsync(id, paciente);
            if (!editPaciente)
                return NotFound(new { mensaje = "Paciente no actualizado" });
            
            return Ok("PAciente actualizado");
        }

        /// <summary>
        /// Acción para eliminar una cita por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacientes(int id)
        {
            return Ok();
        }
    }
}
