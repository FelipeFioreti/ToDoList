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
        private readonly TokenService _tokenService;
        public UserController(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Usuário não encontrado.");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userService.AddAsync(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var existingUser = await _userService.UpdateAsync(user);
            return Ok(existingUser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User loginData)
        {

            var token = await _userService.Login(loginData);

            if (token != null)
                return Ok(token);

            return BadRequest("Erro ao logar o usuário.");
            
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var token = await _tokenService.AuthenticateToken(_tokenService.GetTokenToString(HttpContext.Request.Headers.Authorization.ToString()));
            await _tokenService.Delete(token!.UserId);

            return Ok("Usuário deslogado com sucesso.");
        }
    }
}
