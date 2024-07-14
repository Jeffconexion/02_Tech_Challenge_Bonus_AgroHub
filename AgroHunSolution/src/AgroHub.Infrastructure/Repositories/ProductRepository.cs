using AgroHub.Domain.Entities;
using AgroHub.Domain.IRepositories;
using AgroHub.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroHub.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<Product> GetProductById(Guid id)
        {
            var products = Db.Products
                              .Include(p => p.Category)
                              .Where(p => p.Id == id)
                              .FirstOrDefault();

            return products;
        }
    }
}
