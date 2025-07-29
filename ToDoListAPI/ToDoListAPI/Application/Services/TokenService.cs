using ToDoListAPI.Application.Utils;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;

namespace ToDoListAPI.Application.Services
{
    public class TokenService
    {
        private readonly IJwtTokenRepository _repository;
        private readonly JwtUtils _token;
        public TokenService(IJwtTokenRepository jwtTokenRepository, JwtUtils token) 
        {
            _repository = jwtTokenRepository;
            _token = token;
        }
        
        public async Task<Token?> AuthenticateToken(string token)
        {
            var tokenValue = await _repository.GetToken(token) ?? throw new Exception("Não token não encontrado");

            if (_token.ValidateToken(tokenValue.Value))
            {
                return tokenValue;
            }

            throw new Exception("Token inválido ou expirado");
        }

        public async Task<String?> Create(int userId)
        {
            var token = await _repository.GetTokenByUserId(userId);

            if (token != null)
            {
                if (_token.ValidateToken(token.Value))
                {
                    return token.Value;
                }

                await _repository.Delete(token);
            }

            token = _token.GenerateToken(userId); 
            await _repository.Create(token);

            return token.Value;
        }

        public async Task Delete(int userId)
        {
            var token = await _repository.GetTokenByUserId(userId);

            if (token != null)
            {
                await _repository.Delete(token);
            }
            else
            {
                throw new KeyNotFoundException("Token não foi encontrado");
            }
        }

        public string GetTokenToString(string token)
        {
            if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                throw new KeyNotFoundException("Token não encontrado");

            return token["Bearer ".Length..].Trim(); ;
        }

    }
}
