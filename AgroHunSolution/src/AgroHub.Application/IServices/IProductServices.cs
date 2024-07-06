using AgroHub.Domain.Entities;

namespace AgroHub.Application.IServices
{
    public interface IProductServices
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid idProduct);
        Task GetAll();
        Task GetAllByFilter(string name);
    }
}
