using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Domain.Interfaces
{
    public interface IJwtTokenRepository
    {
        Task Create(Token token);
        Task Delete(Token token);
        Task<Token?> GetToken(string value);
        Task<Token?> GetTokenByUserId(int Id);
    }
}
