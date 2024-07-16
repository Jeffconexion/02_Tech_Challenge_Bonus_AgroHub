using AgroHub.Application.Request;
using AgroHub.Application.Response;
using AgroHub.Domain.Entities;

namespace AgroHub.Application.IServices
{
    public interface IProductServices
    {
        Task<ApiResponse<Product>> Add(ProductRequest productRequest);
        Task<ApiResponse<Product>> Update(Guid idProduct, ProductRequest productRequest);
        Task<ApiResponse<Product>> Delete(Guid idProduct);
        Task<ApiResponse<Product>> GetAll(int page, int pageSize);
        Task<ApiResponse<Product>> GetAllByFilter(string name, int page, int pageSize);
    }
}
