﻿using AgroHub.Application.IServices;
using AgroHub.Application.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="productRequest">The product details to create.</param>
        /// <returns>A response indicating the result of the creation operation.</returns>
        /// <response code="201">Returns the created product.</response>
        /// <response code="400">If the product data is invalid.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost("create")]
        [SwaggerResponse(201, "Returns the created product")]
        [SwaggerResponse(400, "If the product data is invalid")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> CreateProduct(ProductRequest productRequest)
        {
            var response = await _productServices.Add(productRequest);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="idProduct">The ID of the product to update.</param>
        /// <param name="productRequest">The updated product details.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        /// <response code="200">Returns the updated product.</response>
        /// <response code="400">If the product data is invalid.</response>
        /// <response code="404">If the product is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPut("update")]
        [SwaggerResponse(200, "Returns the updated product")]
        [SwaggerResponse(400, "If the product data is invalid")]
        [SwaggerResponse(404, "If the product is not found")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> UpdateProduct(Guid idProduct, ProductRequest productRequest)
        {
            var response = await _productServices.Update(idProduct, productRequest);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="idProduct">The ID of the product to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        /// <response code="200">Returns a confirmation that the product was deleted.</response>
        /// <response code="400">If the product ID is invalid.</response>
        /// <response code="404">If the product is not found.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpDelete("delete")]
        [SwaggerResponse(200, "Returns a confirmation that the product was deleted")]
        [SwaggerResponse(400, "If the product ID is invalid")]
        [SwaggerResponse(404, "If the product is not found")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> DeleteProduct(Guid idProduct)
        {
            var response = await _productServices.Delete(idProduct);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A response containing a list of products.</returns>
        /// <response code="200">Returns the list of products.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("list-all")]
        [SwaggerResponse(200, "Returns the list of products")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productServices.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Retrieves products by filter based on name.
        /// </summary>
        /// <param name="name">The name to filter products by.</param>
        /// <returns>A response containing filtered products.</returns>
        /// <response code="200">Returns the filtered products.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpGet("list-by-filter")]
        [SwaggerResponse(200, "Returns the filtered products")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> GetByFilterNameProduct(string name)
        {
            var response = await _productServices.GetAllByFilter(name);
            return StatusCode(response.StatusCode, response);
        }
    }
}
