using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListAPI.Application;
using ToDoListAPI.Application.UseCases;
using ToDoListAPI.Domain.DataBaseInterfaces;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Controllers
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

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.AddAsync(user);

            return Ok(user);
        }
    }
}
