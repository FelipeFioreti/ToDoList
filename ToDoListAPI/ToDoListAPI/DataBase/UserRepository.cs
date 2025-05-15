using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.DataBase
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> IsEmailExists(string email)
        {
            if (await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (user == null)
                    return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;

            }catch(Exception ex)
            {
                return false;
            }

        }

        public async Task<User> UpdateUser(User userModel)
        {
            try
            {
                _context.Entry(userModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

