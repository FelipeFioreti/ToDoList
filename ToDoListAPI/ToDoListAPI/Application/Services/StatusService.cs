using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Repositories;
using ToDoListAPI.Infrastructure.Repositories.Comoom;

namespace ToDoListAPI.Application.Services
{
    public class StatusService : IStatusRepository
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
                _statusRepository = statusRepository;
        }

        public async Task AddAsync(Status status)
        {
            if(status == null)
            {
                throw new ArgumentNullException(nameof(status), "Status não pode ser nulo.");
            }

            if(string.IsNullOrWhiteSpace(status.Name))
            {
                throw new ArgumentException("Nome do Status não pode ser nulo.", nameof(status.Name));
            }

            await _statusRepository.AddAsync(status);
        }

        public async Task Delete(Status status)
        {
            if(status == null)
            {
                throw new ArgumentNullException(nameof(status), "Status não pode ser nulo.");
            }

            var response = await _statusRepository.GetByIdAsync(status.StatusId);

            if (response == null)
            {
                throw new KeyNotFoundException($"Status não existe.");
            }

            await _statusRepository.Delete(status);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _statusRepository.GetAllAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return await _statusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Status status)
        {
            if(status == null)
            {
                throw new ArgumentNullException(nameof(status), "Status não pode ser nulo.");
            }

            if(string.IsNullOrWhiteSpace(status.Name))
            {
                throw new ArgumentException("Nome do Status não pode ser nulo.", nameof(status.Name));
            }

            var existingStatus = await _statusRepository.GetByIdAsync(status.StatusId) ?? throw new KeyNotFoundException($"Status não encontrado.");

            await _statusRepository.UpdateAsync(status);

        }
    }
}
