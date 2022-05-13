namespace ToysAndGames.Model.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
     
        Task<IEnumerable<T>> GetAll();
        Task DeleteAsync(int id);
    }
}