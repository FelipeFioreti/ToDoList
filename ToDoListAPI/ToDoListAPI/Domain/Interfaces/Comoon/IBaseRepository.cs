
namespace ToDoListAPI.Domain.Interfaces.Comoon
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity user);
        Task UpdateAsync(TEntity user);
        Task Delete(TEntity user);
        
    }
}
