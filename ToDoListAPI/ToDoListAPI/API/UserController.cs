using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;


namespace ToDoListAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Usuário não encontrado.");
            }

            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("É necessário preencher os atributos do usuário.");
            }

            await _userService.AddAsync(user);

            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Usuário não encontrado.");
            }

            await _userService.Delete(user);
            return Ok($"Usuário deletado com sucesso.");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }
            var existingUser = await _userService.GetByIdAsync(user.UserId);

            if (existingUser == null)
            {
                return NotFound($"Usuário não encontrado.");
            }

            await _userService.UpdateAsync(user);
            return Ok(user);
        }
    }
}
