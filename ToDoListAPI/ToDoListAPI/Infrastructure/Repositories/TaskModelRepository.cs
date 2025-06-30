<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
﻿using ToDoListAPI.Domain.DataBaseInterfaces;
using ToDoListAPI.Entities;
=======
﻿using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs

namespace ToDoListAPI.Infrastructure.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
        public Task AddAsync(TaskModel user)
=======
        private readonly ApplicationContext context;

        public TaskModelRepository(ApplicationContext context)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs
        {
               this.context = context;
        }
        public async Task AddTaskModel(TaskModel task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
        public Task DeleteAsync(TaskModel user)
=======
        public async Task DeleteTaskModel(int taskId)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs
        {
            var task = await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId); 
            
            if (task == null)
                return;

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
        public Task<IEnumerable<TaskModel>> GetAllAsync()
=======
        public async Task<IEnumerable<TaskModel>> GetTasksModel()
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs
        {
            return await context.Tasks.ToListAsync();
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
        public Task<TaskModel> GetByIdAsync(int id)
=======

        public async Task<TaskModel> GetTaskModelById(int taskId)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs
        {
            return await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId);
        }

<<<<<<< HEAD:ToDoListAPI/ToDoListAPI/Infrastructure/Repositories/TaskModelRepository.cs
        public Task UpdateAsync(TaskModel user)
=======
        public async Task UpdateTaskModel(TaskModel status)
>>>>>>> 08444b2 (Adicionando métodos ao controlador de usuários):ToDoListAPI/ToDoListAPI/DataBase/TaskModelRepository.cs
        {
            var task = await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == status.TaskId);
            
            if (task == null)
                return;

            context.Update(task);
            await context.SaveChangesAsync();
        }
    }
}
