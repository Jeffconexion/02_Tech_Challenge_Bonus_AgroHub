using AgroHub.Application.Dtos;
using AgroHub.Application.Request;
using AgroHub.Application.Services;
using AgroHub.Domain.Entities;
using AgroHub.Domain.IRepositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace AgroHub.UnitTests.ApplicationTests.Services
{
    public class ProductServicesTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ILogger<ProductServices>> _mockLogger;
        private readonly ProductServices _productServices;

        public ProductServicesTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockLogger = new Mock<ILogger<ProductServices>>();
            _productServices = new ProductServices(_mockProductRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Add_ShouldReturnSuccessfulResponse_WhenProductIsAdded()
        {
            // Arrange
            var productRequest = new ProductRequest
            {
                Data = new List<ProductDto>
            {
                new ProductDto
                {
                    Name = "Test Product",
                    // Adicione outros campos conforme necessário
                }
            }
            };

            _mockProductRepository
                .Setup(repo => repo.Add(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            // Act
            var response = await _productServices.Add(productRequest);

            // Assert
            response.StatusCode.Should().Be(201);
            response.Message.Should().Be("Product successfully created!");
            response.Success.Should().BeTrue();
            _mockProductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldReturnErrorResponse_WhenExceptionIsThrown()
        {
            // Arrange
            var productRequest = new ProductRequest
            {
                Data = new List<ProductDto>
            {
                new ProductDto
                {
                    Name = "Test Product",
                    // Adicione outros campos conforme necessário
                }
            }
            };

            _mockProductRepository
                .Setup(repo => repo.Add(It.IsAny<Product>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var response = await _productServices.Add(productRequest);

            // Assert
            response.StatusCode.Should().Be(500);
            response.Message.Should().Be("Database error");
            response.Success.Should().BeFalse();
            _mockProductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnSuccessfulResponse_WhenProductIsDeleted()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product { Id = productId, Name = "Test Product" };

            _mockProductRepository.Setup(repo => repo.GetById(productId))
                                  .ReturnsAsync(product);
            _mockProductRepository.Setup(repo => repo.Delete(productId))
                                  .Returns(Task.CompletedTask);

            // Act
            var response = await _productServices.Delete(productId);

            // Assert
            response.StatusCode.Should().Be(200);
            response.Message.Should().Be("Product successfully deleted!");
            response.Success.Should().BeTrue();
            response.Data.Should().Be(product);
            _mockProductRepository.Verify(repo => repo.GetById(productId), Times.Once);
            _mockProductRepository.Verify(repo => repo.Delete(productId), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFoundResponse_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _mockProductRepository.Setup(repo => repo.GetById(productId))
                                  .ReturnsAsync((Product)null);

            // Act
            var response = await _productServices.Delete(productId);

            // Assert
            response.StatusCode.Should().Be(404);
            response.Message.Should().Be("Product not found!");
            response.Success.Should().BeFalse();
            response.Data.Should().BeNull();
            _mockProductRepository.Verify(repo => repo.GetById(productId), Times.Once);
            _mockProductRepository.Verify(repo => repo.Delete(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldReturnErrorResponse_WhenExceptionIsThrown()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product { Id = productId, Name = "Test Product" };

            _mockProductRepository.Setup(repo => repo.GetById(productId))
                                  .ReturnsAsync(product);
            _mockProductRepository.Setup(repo => repo.Delete(productId))
                                  .ThrowsAsync(new Exception("Database error"));

            // Act
            var response = await _productServices.Delete(productId);

            // Assert
            response.StatusCode.Should().Be(500);
            response.Message.Should().Be("Database error");
            response.Success.Should().BeFalse();
            response.Data.Should().BeNull();
            _mockProductRepository.Verify(repo => repo.GetById(productId), Times.Once);
            _mockProductRepository.Verify(repo => repo.Delete(productId), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNotFoundResponse_WhenNoProductsExist()
        {
            // Arrange
            var page = 1;
            var pageSize = 10;

            _mockProductRepository.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Product>());

            // Act
            var response = await _productServices.GetAll(page, pageSize);

            // Assert
            response.StatusCode.Should().Be(404);
            response.Message.Should().Be("Product not found!");
            response.Success.Should().BeFalse();
            response.Datas.Should().BeNull();
            _mockProductRepository.Verify(repo => repo.GetAll(), Times.Once);

        }

        [Fact]
        public async Task GetAll_ShouldReturnErrorResponse_WhenExceptionIsThrown()
        {
            // Arrange
            var page = 1;
            var pageSize = 10;

            _mockProductRepository.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception("Database error"));

            // Act
            var response = await _productServices.GetAll(page, pageSize);

            // Assert
            response.StatusCode.Should().Be(500);
            response.Message.Should().Be("Database error");
            response.Success.Should().BeFalse();
            response.Datas.Should().BeNull();
            _mockProductRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
