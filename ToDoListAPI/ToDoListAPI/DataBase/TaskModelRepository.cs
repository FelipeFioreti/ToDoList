using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;
using ToDoListAPI.UseCase.DataBaseInterfaces;

namespace ToDoListAPI.DataBase
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private readonly ApplicationContext context;

        public TaskModelRepository(ApplicationContext context)
        {
               this.context = context;
        }
        public async Task AddTaskModel(TaskModel task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTaskModel(int taskId)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId); 
            
            if (task == null)
                return;

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetTasksModel()
        {
            return await context.Tasks.ToListAsync();
        }


        public async Task<TaskModel> GetTaskModelById(int taskId)
        {
            return await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == taskId);
        }

        public async Task UpdateTaskModel(TaskModel status)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(x => x.TaskId == status.TaskId);
            
            if (task == null)
                return;

            context.Update(task);
            await context.SaveChangesAsync();
        }
    }
}
