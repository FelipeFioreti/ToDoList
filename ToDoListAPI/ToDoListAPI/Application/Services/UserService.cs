using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Infrastructure.Repositories;

namespace ToDoListAPI.Application.Services
{
    public class UserService : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;
        public UserService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<User> AddAsync(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("É necessário preencher os atributos do usuário.", nameof(user));
            }

            user.Update();

            return await _userRepository.AddAsync(user);
        }

        public async Task Delete(User user)
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");

            var userToDelete = await _userRepository.GetByIdAsync(user.Id) ?? throw new KeyNotFoundException($"Usuário não existe.");

            await _userRepository.Delete(userToDelete);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("É necessário preencher os atributos do usuário.", nameof(user));
            }

            var userToUpdate = await _userRepository.GetByIdAsync(user.Id) ?? throw new KeyNotFoundException("Usuário Não encontrado.");

            userToUpdate.UpdatePassword(user.Password);
            userToUpdate.Update(userToUpdate.Name, user.Email, user.Password);

            return await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task<Token?> Login(User loginData)
        {
            var user = await GetByEmailAssync(loginData.Email) ?? throw new Exception("Email inválido.");

            if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
            {
                throw new Exception("Senha inválida.");   
            }

            var token = await _tokenService.Create(user.Id) ?? throw new Exception("Erro ao criar o Token");

            return token;
        }

        public async Task<User?> GetByEmailAssync(string email)
        {
            return await _userRepository.GetByEmailAssync(email) ?? 
                throw new KeyNotFoundException("Usuário não encontrado.");
        }
    }
}
