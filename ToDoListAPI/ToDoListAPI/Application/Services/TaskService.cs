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

        public async Task AddAsync(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            if (string.IsNullOrEmpty(task.Title) || string.IsNullOrEmpty(task.Content))
            {
                throw new ArgumentException("É necessário preencher os atributos da tarefa.", nameof(task));
            }

            task.CreatedAt = DateTime.UtcNow;

            await _taskModelRepository.AddAsync(task);

        }

        public Task Delete(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            var response = _taskModelRepository.GetByIdAsync(task.TaskId);

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

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            return await _taskModelRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Tarefa não pode ser nula.");
            }

            var response = _taskModelRepository.GetByIdAsync(task.TaskId);

            if (response == null)
            {
                throw new KeyNotFoundException($"Tarefa não existe.");
            }

            await _taskModelRepository.UpdateAsync(task);
        }
    }
}
