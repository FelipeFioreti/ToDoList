using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.UseCase.DataBaseInterfaces
{
    public interface IStatusRepository
    {
        Status GetStatusById(int id);
        IEnumerable<Status> GetStatus();
        void AddStatus(Status status);
        void UpdateStatus(Status status);
        void DeleteStatus(int id);
    }
}
