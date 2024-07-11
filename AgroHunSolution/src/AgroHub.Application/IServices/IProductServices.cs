using AgroHub.Application.Request;

namespace AgroHub.Application.IServices
{
    public interface IProductServices
    {
        Task Add(ProductRequest productRequest);
        Task Update(Guid idProduct, ProductRequest productRequest);
        Task Delete(Guid idProduct);
        Task GetAll();
        Task GetAllByFilter(string name);
    }
}
