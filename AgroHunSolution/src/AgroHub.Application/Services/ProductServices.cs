using AgroHub.Application.IServices;
using AgroHub.Application.Request;
using AgroHub.Domain.IRepositories;

namespace AgroHub.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(ProductRequest productRequest)
        {
            var product = productRequest.ToEntity();
            await _productRepository.Add(product);
        }

        public async Task Delete(Guid idProduct)
        {
            var product = await _productRepository.GetById(idProduct);

            if (product is not null)
            {
                await _productRepository.Delete(product.Id);
            }
        }

        public async Task GetAll()
        {
            var products = await _productRepository.GetAll();
        }

        public async Task GetAllByFilter(string name)
        {
            var products = await _productRepository.Search(x => x.Name.Equals(name));
        }

        public async Task Update(Guid idProduct, ProductRequest productRequest)
        {
            var productRecorded = await _productRepository.GetById(idProduct);

            if (productRecorded is not null)
            {
                var product = productRequest.ToEntity();

                productRecorded.Name = product.Name;
                productRecorded.Value = product.Value;
                await _productRepository.Update(productRecorded);
            }
        }
    }
}
