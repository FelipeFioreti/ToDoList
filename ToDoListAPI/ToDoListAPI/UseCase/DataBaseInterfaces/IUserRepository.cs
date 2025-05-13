using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.UseCase.DataBaseInterfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserByEmail(string email);
        bool IsEmailExists(string email);
    }
}
