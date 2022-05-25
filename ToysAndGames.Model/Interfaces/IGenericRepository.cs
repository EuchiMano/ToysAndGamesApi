namespace ToysAndGames.Model.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task DeleteAsync(T entity);
    }
}