using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Infrastructure.Repositories.Base;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly ApplicationDbContext context;

        public StatusRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
