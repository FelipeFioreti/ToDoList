using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Infrastructure.Repositories.Base;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class TaskModelRepository : BaseRepository<TaskModel>, ITaskModelRepository
    {
        private readonly ApplicationDbContext context;
        public TaskModelRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.context = applicationDbContext;
        }
    }
}
