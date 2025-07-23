using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Infrastructure.Repositories.Base;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User?> GetByEmailAssync(string email)
        {
            return await _context.Set<User>().SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}

