using AgroHub.Domain.Entities;
using System.Linq.Expressions;

namespace AgroHub.Domain.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}