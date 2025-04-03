using AgendamientosCitas.Citas.Application.Dtos.Dto;
using AgendamientosCitas.Citas.Application.Interfasces;
using AgendamientosCitas.Citas.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientosCitas.Citas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService) 
        {
            _citaService = citaService;
        }

        /// <summary>
        /// Acción para obtener todas las citas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCitas()
        {
            var citas = await _citaService.GetTodasLasCitasAsync();
            if (citas == null)
                return NotFound(new { mensaje = "No se encontro ningun cita" });

            return Ok(citas);
        }

        /// <summary>
        /// Acción para obtener una cita específica por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitasId(int id)
        {
            var cita = await _citaService.GetCitaPorIdAsync(id);
            if (cita == null)
                return NotFound(new { mensaje = "Cita no encontrada" });

            return Ok(cita);
        }

        /// <summary>
        /// Acción para obtener todas las citas de un paciente específico por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("paciente/{id}")]
        public async Task<IActionResult> GetCitasPorPaciente(int id)
        {

            var citas = await _citaService.GetCitaPorIdPacienteAsync(id);
            if (citas == null)
                return NotFound(new { mensaje = "Cita no encontrada" });

            return Ok(citas);
        }

        /// <summary>
        /// Acción para agregar una nueva cita
        /// </summary>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCitas(CitaDto cita)
        {
            var NewCita = await _citaService.AddCitaAsync(cita);
            if (!NewCita)
                return NotFound(new { mensaje = "Cita no asignada" });

            return Ok("Cita asignada");
        }

        /// <summary>
        /// Acción para actualizar una cita existente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCitas(int id, CitaDto cita)
        {
            var EditCita = await _citaService.UpdateCitaAsync(id,cita);
            if (!EditCita)
                return NotFound(new { mensaje = "No se pudo cambiar cita" });

            return Ok("Cambio de Cita Realizado");
        }

        /// <summary>
        /// Acción para eliminar una cita por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitas(int id)
        {
            return Ok();
        }
    }
}
