using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DataBase;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.AddUser(user);

            return Created();
        }
    }
}
