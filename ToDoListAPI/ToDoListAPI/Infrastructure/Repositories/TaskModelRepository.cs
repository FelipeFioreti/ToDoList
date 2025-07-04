using ToDoListAPI.Infrastructure.Repositories.Comoom;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class TaskModelRepository : BaseRepository<TaskModel>, ITaskModelRepository
    {
        private readonly ApplicationDbContext context;
        public TaskModelRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            context = applicationDbContext;
        }
    }
}
