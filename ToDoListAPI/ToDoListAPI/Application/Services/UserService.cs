using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Application.Services
{
    public class UserService : IUserRepository
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
                _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("É necessário preencher os atributos do usuário.", nameof(user));
            }
         
            user.CreatedAt = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
        }

        public async Task Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            var response = await _userRepository.GetByIdAsync(user.UserId);

            if (response == null)
            {
                throw new KeyNotFoundException($"Usuário não existe.");
            }

            await _userRepository.Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("É necessário preencher os atributos do usuário.", nameof(user));
            }

            var existingUser = await _userRepository.GetByIdAsync(user.UserId) ?? throw new KeyNotFoundException("Usuário Não encontrado.")  ;

            await _userRepository.UpdateAsync(user);
        }
    }
}
