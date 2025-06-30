<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
﻿using ToDoListAPI.Domain.DataBaseInterfaces;
using ToDoListAPI.Entities;
=======
﻿using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
        public Task AddAsync(Status user)
=======
        private readonly ApplicationContext _context;
        public StatusRepository(ApplicationContext _context)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs
        {
            this._context = _context;
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
        public Task DeleteAsync(Status user)
=======
        public async Task<Status> AddStatus(Status status)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs
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

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
        public Task<IEnumerable<Status>> GetAllAsync()
=======
        public async Task<bool> DeleteStatus(int statusId)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs
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

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
        public Task<Status> GetByIdAsync(int id)
=======
        public async Task<IEnumerable<Status>> GetStatus()
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs
        {
            return await _context.Status.ToListAsync();
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/StatusRepository.cs
        public Task UpdateAsync(Status user)
=======
        public Task<Status> GetStatusById(int id)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/StatusRepository.cs
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
