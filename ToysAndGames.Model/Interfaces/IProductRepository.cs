using ToysAndGames.Model.Products;

namespace ToysAndGames.Model.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetById(int id);
    }
}