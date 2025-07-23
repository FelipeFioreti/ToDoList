using ToDoListAPI.Domain.Interfaces.Base;
using ToDoListAPI.Domain.Entities;
using System.Data;

namespace ToDoListAPI.Domain.Interfaces
{
    public interface ITaskModelRepository : IBaseRepository<TaskModel>
    {
    }
}
