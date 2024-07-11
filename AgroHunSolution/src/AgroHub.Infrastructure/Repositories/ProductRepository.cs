using AgroHub.Domain.Entities;
using AgroHub.Domain.IRepositories;
using AgroHub.Infrastructure.Data.Context;

namespace AgroHub.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
