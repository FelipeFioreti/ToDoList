using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.UseCase.DataBaseInterfaces
{
    public interface ITaskModelRepository
    {
        Task<TaskModel> GetTaskModelById(int id);
        Task<IEnumerable<TaskModel>> GetTasksModel();
        Task AddTaskModel(TaskModel status);
        Task UpdateTaskModel(TaskModel status);
        Task DeleteTaskModel(int id);
    }
}
