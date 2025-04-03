using AgendamientoCitas.Medicos.Application.Dtos.Dto;
using AgendamientoCitas.Medicos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoCitas.Medicos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosService _medicoService;

        public MedicosController(IMedicosService medicoService)
        {
            _medicoService = medicoService;
        }
        /// <summary>
        /// Acción para obtener todas las citas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMedicos()
        {
            var medicos = await _medicoService.GetTodasLosMedicosAsync();
            if (medicos == null)
                return NotFound(new { mensaje = "No se encontro ningun medico" });

            return Ok(medicos);
        }

        /// <summary>
        /// Acción para obtener una cita específica por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicosId(int id)
        {
            var medico = await _medicoService.GetMedicoPorIdAsync(id);
            if (medico == null)
                return NotFound(new { mensaje = "Medico no encontrada" });

            return Ok(medico);
        }

        /// <summary>
        /// Acción para agregar una nueva cita
        /// </summary>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMedicos(MedicoDto medico)
        {
            var newMedico = await _medicoService.AddMedicossync(medico);
            if(!newMedico)
                return NotFound(new { mensaje = "Medico no creado" });
            
            return Ok("Medico Creado");
        }

        /// <summary>
        /// Acción para actualizar una cita existente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicos(int id, MedicoDto medico)//, Cita cita)
        {
            var editMedico = await _medicoService.UpdateMedicoAsync(id,medico);
            if (!editMedico)
                return NotFound(new { mensaje = "Medico no Actualizado" });

            return Ok("Medico Actualizado");
        }

        /// <summary>
        /// Acción para eliminar una cita por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(int id)
        {
            return Ok();
        }
    }
}
