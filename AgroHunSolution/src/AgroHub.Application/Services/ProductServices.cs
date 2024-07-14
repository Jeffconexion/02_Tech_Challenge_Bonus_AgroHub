using AgroHub.Application.IServices;
using AgroHub.Application.Request;
using AgroHub.Application.Response;
using AgroHub.Application.Response.ResponseUtilities;
using AgroHub.Domain.Entities;
using AgroHub.Domain.IRepositories;

namespace AgroHub.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly HttpResponseUtils _httpResponseUtils;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _httpResponseUtils = new HttpResponseUtils();
        }

        public async Task<ApiResponse<Product>> Add(ProductRequest productRequest)
        {
            var product = productRequest.Data.First().ToEntity();
            try
            {
                await _productRepository.Add(product);
                return _httpResponseUtils.SuccessfulResponseCreated(product, "Product successfully created!");
            }
            catch (Exception ex)
            {
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }

        public async Task<ApiResponse<Product>> Delete(Guid idProduct)
        {
            var product = await _productRepository.GetById(idProduct);

            try
            {
                if (product is not null)
                {
                    await _productRepository.Delete(product.Id);
                    return _httpResponseUtils.SuccessfulResponseOk(product, "Product successfully deleted!");
                }
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }

        public async Task<ApiResponse<Product>> GetAll()
        {
            try
            {
                var products = await _productRepository.GetAll();

                if (products.Any())
                {
                    return _httpResponseUtils.SuccessfulResponseWithPagination(products, "Products retrieved successfully!");
                }
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");

            }
            catch (Exception ex)
            {
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }

        public async Task<ApiResponse<Product>> GetAllByFilter(string name)
        {
            try
            {
                var products = await _productRepository.Search(x => x.Name.Equals(name));

                if (products.Any())
                {
                    return _httpResponseUtils.SuccessfulResponseWithPagination(products.ToList(), "Products retrieved successfully!");
                }
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }

        public async Task<ApiResponse<Product>> Update(Guid idProduct, ProductRequest productRequest)
        {
            try
            {
                var productRecorded = await _productRepository.GetProductById(idProduct);
                var product = productRequest.Data.First().ToEntity();

                if (productRecorded is not null)
                {
                    productRecorded.Name = product.Name;
                    productRecorded.Description = product.Description;
                    productRecorded.Image = product.Image;
                    productRecorded.Value = product.Value;
                    productRecorded.Quantity = product.Quantity;
                    productRecorded.Unit = product.Unit;
                    productRecorded.Category.Name = product.Category.Name;
                    await _productRepository.Update(productRecorded);
                    return _httpResponseUtils.SuccessfulResponseOk(product, "Product successfully updated!");
                }

                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }
    }
}
