using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Infrastructure.Context;

namespace ToDoListAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;
        public TaskController(TaskService service) 
        {
            _service = service;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound($"Tarefa não encontrada.");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskModel task)
        {
            await _service.AddAsync(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound($"Tarefa não encontrada.");
            }

            await _service.Delete(task);
            return Ok($"Tarefa deletada com sucesso.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskModel task)
        {
            await _service.UpdateAsync(task);
            return Ok(task);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] TaskModel task)
        {
            await _service.UpdateStatusAsync(task);
            return Ok(task);
        }

    }
}
