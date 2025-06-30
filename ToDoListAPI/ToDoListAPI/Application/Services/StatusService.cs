using ToDoListAPI.Domain.DataBaseInterfaces;
using ToDoListAPI.Entities;
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

        public Task AddAsync(Status user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Status user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Status>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Status user)
        {
            throw new NotImplementedException();
        }
    }
}
