using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Repositories;
using ToDoListAPI.Infrastructure.Repositories.Base;

namespace ToDoListAPI.Application.Services
{
    public class StatusService : IStatusRepository
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
                _statusRepository = statusRepository;
        }

        public async Task<Status> AddAsync(Status status)
        {
            if(status == null)
            {
                throw new ArgumentNullException(nameof(status), "Status não pode ser nulo.");
            }

            return await _statusRepository.AddAsync(status);
        }

        public async Task Delete(Status status)
        {
            var statusToDelete = await _statusRepository.GetByIdAsync(status.Id) ?? throw new KeyNotFoundException($"Status não existe."); ;

            await _statusRepository.Delete(statusToDelete);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _statusRepository.GetAllAsync();
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await _statusRepository.GetByIdAsync(id);
        }

        public async Task<Status> UpdateAsync(Status status)
        {
            var statusToUpdate = await _statusRepository.GetByIdAsync(status.Id) ?? throw new KeyNotFoundException($"Status não encontrado.");

            statusToUpdate.Update(status.Name);

            return await _statusRepository.UpdateAsync(statusToUpdate);
        }
    }
}
