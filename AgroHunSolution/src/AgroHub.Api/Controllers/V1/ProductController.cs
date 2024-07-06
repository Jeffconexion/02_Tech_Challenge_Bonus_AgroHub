using AgroHub.Application.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace AgroHub.Api.Controllers.V1
{
    [Route("api/[controller]")]
    public class ProductController : MainController
    {
        [HttpPost("create")]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct(Guid idProduct)
        {
            return Ok();
        }

        [HttpGet("list-all")]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpGet("list-by-filter")]
        public IActionResult AddProduct(string name)
        {
            return Ok();
        }
    }
}
