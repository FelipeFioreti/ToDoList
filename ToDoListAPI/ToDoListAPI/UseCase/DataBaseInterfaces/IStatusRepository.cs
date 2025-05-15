using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.UseCase.DataBaseInterfaces
{
    public interface IStatusRepository
    {
        Task<Status> GetStatusById(int id);
        Task<IEnumerable<Status>> GetStatus();
        Task<Status> AddStatus(Status status);
        Task<Status> UpdateStatus(Status status);
        Task<bool> DeleteStatus(int id);
    }
}
