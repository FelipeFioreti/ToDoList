
namespace ToDoListAPI.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity user);
        Task<TEntity> UpdateAsync(TEntity user);
        Task Delete(TEntity user);
        
    }
}
