using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Interfaces;

namespace ToDoListAPI.Application.Services
{
    public class TaskService : ITaskModelRepository
    {
        private readonly ITaskModelRepository _taskModelRepository;

        public TaskService(ITaskModelRepository taskModelRepository)
        {
            _taskModelRepository = taskModelRepository;
        }

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            if (string.IsNullOrEmpty(task.Title) || string.IsNullOrEmpty(task.Content))
            {
                throw new ArgumentException("É necessário preencher os atributos da tarefa.", nameof(task));
            }

            task.Update(task.Title, task.Content);

            return await _taskModelRepository.AddAsync(task);

        }

        public Task Delete(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            var response = _taskModelRepository.GetByIdAsync(task.Id);

            if (response == null)
            {
                throw new KeyNotFoundException($"Tarefa não existe.");
            }

            return _taskModelRepository.Delete(task);

        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            return await _taskModelRepository.GetAllAsync();
        }

        public async Task<TaskModel?> GetByIdAsync(int id)
        {
            return await _taskModelRepository.GetByIdAsync(id);
        }

        public async Task<TaskModel> UpdateAsync(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            var taskToUpdate = await _taskModelRepository.GetByIdAsync(task.Id) ?? 
                throw new KeyNotFoundException($"Tarefa não existe.");

            taskToUpdate.Update(task.Title, task.Content);

            return await _taskModelRepository.UpdateAsync(taskToUpdate);
        }

        public async Task<TaskModel> UpdateStatusAsync(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            var taskToUpdate = await _taskModelRepository.GetByIdAsync(task.Id) ??
                throw new KeyNotFoundException($"Tarefa não existe.");

            taskToUpdate.UpdateStatus(task.StatusId);

            return await _taskModelRepository.UpdateAsync(taskToUpdate);
        }
    }
}
