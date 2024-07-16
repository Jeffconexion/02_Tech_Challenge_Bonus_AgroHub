using AgroHub.Application.IServices;
using AgroHub.Application.Request;
using AgroHub.Application.Response;
using AgroHub.Application.Response.ResponseUtilities;
using AgroHub.Domain.Entities;
using AgroHub.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace AgroHub.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly HttpResponseUtils _httpResponseUtils;
        private readonly ILogger<ProductServices> _logger;

        public ProductServices(IProductRepository productRepository,                               
                               ILogger<ProductServices> logger)
        {
            _productRepository = productRepository;
            _httpResponseUtils = new HttpResponseUtils(); ;
            _logger = logger;
        }


        public async Task<ApiResponse<Product>> Add(ProductRequest productRequest)
        {
            var product = productRequest.Data.First().ToEntity();
            try
            {
                await _productRepository.Add(product);
                _logger.LogInformation($"Product created successfully: {product.Name}");

                return _httpResponseUtils.SuccessfulResponseCreated(product, "Product successfully created!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a product.");
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
                    _logger.LogInformation($"Delete method called for Product ID: {product.Id}");

                    return _httpResponseUtils.SuccessfulResponseOk(product, "Product successfully deleted!");
                }
                _logger.LogInformation($"Product not found: {product.Id}");
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while delete a product.");
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
                    _logger.LogInformation($"Products retrieved successfully!, total products: {products.Count}");

                    return _httpResponseUtils.SuccessfulResponseWithPagination(products, "Products retrieved successfully!");
                }
                _logger.LogInformation("Products not found!");
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get all product.");
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
                    _logger.LogInformation($"Products retrieved successfully!, total products: {products.Count()}");

                    return _httpResponseUtils.SuccessfulResponseWithPagination(products.ToList(), "Products retrieved successfully!");
                }
                _logger.LogInformation("Products not found!");
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get by filter.");
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

                    _logger.LogInformation($"Product update successfully: {product.Name}");
                    return _httpResponseUtils.SuccessfulResponseOk(product, "Product successfully updated!");
                }

                _logger.LogInformation("Product not found!");
                return _httpResponseUtils.NotFoundResponse<Product>("Product not found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while update a product.");
                return _httpResponseUtils.InternalServerErrorResponse<Product>(ex.Message);
            }
        }
    }
}
