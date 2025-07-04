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
                return NotFound($"Tarefa não encontrada.");
            }

            return Ok(task);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Tarefa não pode ser nula.");
            }

            if (string.IsNullOrEmpty(task.Title) || string.IsNullOrEmpty(task.Content))
            {
                return BadRequest("É necessário preencher os atributos da tarefa.");
            }

            await _service.AddAsync(task);
            return Ok(task);
        }

        [HttpDelete("Delete/{id}")]
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

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest("Tarefa não pode ser nula.");
            }

            var existingTask = await _service.GetByIdAsync(task.TaskId);

            if (existingTask == null)
            {
                return NotFound($"Tarefa não encontrada.");
            }

            await _service.UpdateAsync(task);
            return Ok(task);
        }

    }
}
