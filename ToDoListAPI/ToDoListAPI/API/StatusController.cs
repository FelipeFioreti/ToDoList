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
            return Ok(await _service.GetAllAsync());
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
            var response = await _service.UpdateAsync(status);

            if(response == null)
            {
                return BadRequest($"Erro ao atualizar dados.");
            }

            return Ok(status);
        }
    }
}
