using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.DataBase
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationContext _context;
        public StatusRepository(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<Status> AddStatus(Status status)
        {
            try
            {
                await _context.Status.AddAsync(status);
                await _context.SaveChangesAsync();
                return status;
            }catch(Exception ex)
            {
                return null;
            }
           
        }

        public async Task<bool> DeleteStatus(int statusId)
        {
            try
            {
                var status = await _context.Status.FirstOrDefaultAsync(x => x.StatusId == statusId);

                if (status == null)
                    return false;

                _context.Status.Remove(status);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Status>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        public Task<Status> GetStatusById(int id)
        {
            return _context.Status.FirstOrDefaultAsync(x => x.StatusId == id);
        }

        public async Task<Status> UpdateStatus(Status status)
        {
            try
            {
                _context.Entry(status).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return status;
            }
            catch(Exception ex)
            {
                return null;
            }       
        }
    }
}
