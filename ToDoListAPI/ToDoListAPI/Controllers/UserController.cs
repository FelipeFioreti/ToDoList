using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using ToDoListAPI.DataBase;
using ToDoListAPI.Entities.DTOs;
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

        [HttpGet("IsEmailExists/{email}")]
        public async Task<bool> IsEmailExists(string email)
        {
            bool isEmailExists = await _userRepository.IsEmailExists(email);
            return isEmailExists;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await _userRepository.GetUsers();
            
            var userDtos = users.Select(n => n.Adapt<UserDto>()).ToList();

            return Ok(userDtos);
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            User user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            UserDto userDto = user.Adapt<UserDto>();

            return Ok(userDto);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (!await IsEmailExists(email))
            {
                return NotFound("Email não encontrado.");
            }

            User user = await _userRepository.GetUserByEmail(email);

            UserDto userDto = user.Adapt<UserDto>();

            return Ok(userDto);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            if (await IsEmailExists(user.Email))
            {
                return BadRequest("Email já existe.");
            }

            await _userRepository.AddUser(user);

            UserDto userDto = user.Adapt<UserDto>();

            return Created("Criado com sucesso.", userDto);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            await _userRepository.UpdateUser(user);
            
            return NoContent();
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
            return Ok();
        }

    }
}
