using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendamientoCitas.Pacientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Acción para obtener todas las citas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPacientes()
        {
            return Ok();
        }

        /// <summary>
        /// Acción para obtener una cita específica por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacientesId(int id)
        {


            return Ok();
        }

        /// <summary>
        /// Acción para agregar una nueva cita
        /// </summary>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPacientes()//Cita cita)
        {
            return Ok();
        }

        /// <summary>
        /// Acción para actualizar una cita existente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePacientes(int id)//, Cita cita)
        {
            return Ok();
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
