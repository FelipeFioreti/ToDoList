using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _service;
        public StatusController(StatusService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound($"Status não encontrado.");
            }

            return Ok(task);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Status status)
        {
            if (status == null)
            {
                return BadRequest("Status não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(status.Name))
            {
                return BadRequest("É necessário preencher o nome do status.");
            }

            await _service.AddAsync(status);
            return Ok(status);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _service.GetByIdAsync(id);

            if (status == null)
            {
                return NotFound($"Status não encontrado.");
            }
           
            await _service.Delete(status);
            return Ok($"Status deletado com sucesso.");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Status status)
        {
            if (status == null)
            {
                return BadRequest("Status não pode ser nulo.");
            }

            var existingStatus = await _service.GetByIdAsync(status.StatusId);

            if (existingStatus == null)
            {
                return NotFound($"Status não encontrado.");
            }

            await _service.UpdateAsync(status);
            return Ok(status);
        }
    }
}
