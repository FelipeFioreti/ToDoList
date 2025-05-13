using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.DataBase
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = context.Users.Find(userId.ToString());

            if (user == null)
                return;

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserById(int userId)
        {
            return context.Users.Find(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return context.Users.ToList();
        }

        public bool IsEmailExists(string email)
        {
            if (context.Users.Where(x => x.Email == email).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateUser(User userModel)
        {
            var user = context.Users.Find(userModel.UserId);

            if (user != null)
            {
                user.Name = userModel.Name;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                user.UpdatedAt = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
    }
}

