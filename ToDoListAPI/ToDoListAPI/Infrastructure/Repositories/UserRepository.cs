using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Domain.DataBaseInterfaces;
using ToDoListAPI.Entities;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Infrastructure.Repositories.Comoom;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

