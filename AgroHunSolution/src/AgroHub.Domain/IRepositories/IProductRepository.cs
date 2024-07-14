using AgroHub.Domain.Entities;

namespace AgroHub.Domain.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductById(Guid id);
    }
}
