using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.UseCase.DataBaseInterfaces
{
    public interface ITaskModelRepository
    {
        TaskModel GetTaskModelById(int id);
        IEnumerable<TaskModel> GetTaskModel();
        void AddTaskModel(TaskModel status);
        void UpdateTaskModel(TaskModel status);
        void DeleteTaskModel(int id);
    }
}
