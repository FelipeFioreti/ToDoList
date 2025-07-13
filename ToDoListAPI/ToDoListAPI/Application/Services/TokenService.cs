using ToDoListAPI.Domain.Interfaces;

namespace ToDoListAPI.Application.Services
{
    public class TokenService
    {
        private readonly IJwtTokenRepository _repository;
        public TokenService(IJwtTokenRepository jwtTokenRepository) 
        {
            _repository = jwtTokenRepository;
        }
        
    }
}
