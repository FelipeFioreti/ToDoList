using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Context;

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class TokenRepository(ApplicationDbContext context) : IJwtTokenRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Create(Token token)
        {
            await _context.Set<Token>().AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Token token)
        {
            _context.Set<Token>().Remove(token);
            await _context.SaveChangesAsync();
        }

        public async Task<Token?> GetToken(string value)
        {
            return await _context.Set<Token>().SingleOrDefaultAsync(t => t.Value == value);
        }

        public async Task<Token?> GetTokenByUserId(int id)
        {
            return await _context.Set<Token>().FirstOrDefaultAsync(t => t.UserId == id);
        }
    }
}
