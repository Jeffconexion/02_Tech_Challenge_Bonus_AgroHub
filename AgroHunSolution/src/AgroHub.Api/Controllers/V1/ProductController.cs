using AgroHub.Application.IServices;
using AgroHub.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace AgroHub.Api.Controllers.V1
{
    [Route("api/[controller]")]
    public class ProductController : MainController
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(ProductRequest productRequest)
        {
            await _productServices.Add(productRequest);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(Guid idProduct, ProductRequest productRequest)
        {
            await _productServices.Update(idProduct, productRequest);
            return null;
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(Guid idProduct)
        {
            await _productServices.Delete(idProduct);
            return null;
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            await _productServices.GetAll();
            return null;
        }

        [HttpGet("list-by-filter")]
        public async Task<IActionResult> GetByFilterNameProduct(string name)
        {
            await _productServices.GetAllByFilter(name);
            return null;
        }
    }
}
