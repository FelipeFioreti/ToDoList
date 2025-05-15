using Mapster;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.Controllers
{
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this._statusRepository = statusRepository;
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {

            IEnumerable<Status> status = await _statusRepository.GetStatus();

            var statusDtos = status.Select(n => n.Adapt<Status>()).ToList();

            return Ok(statusDtos);
        }


    }
}
