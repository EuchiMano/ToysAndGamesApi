using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToysAndGames.Api.Controllers.Products;
using ToysAndGames.Model.Interfaces;
using ToysAndGames.Model.Products;

namespace ToyAndGames.Test
{
    public class ProductControllerTest
    {
        public const int idProductToTest = 5;
        private readonly ProductsController _productController;
        private readonly Mock<IProductRepository> _productRepoMock = new Mock<IProductRepository>();
        private readonly Mock<IMapper> _loggerMock = new Mock<IMapper>();

        public ProductControllerTest()
        {
            _productController = new ProductsController(_productRepoMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnProducts()
        {
            //Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Description = "test",
                    AgeRestriction = 18,
                    Image = null,
                    Company = "test",
                    Name = "test",
                    Price = 100
                }
            };
            _productRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(products);
            //Act

            var result = await _productController.GetProductsAsync();
            var okObjectResult = (OkObjectResult)result;

            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(products, okObjectResult.Value);
        }

        [Fact]
        public async Task DeleteProductByIdAsync_ShouldReturnFail()
        {
            //Arrange

            //Act
            var result = await _productController.DeleteProductByIdAsync(idProductToTest);
            var okObjectResult = (NotFoundObjectResult)result;
            //Assert
            Assert.IsType<NotFoundObjectResult>(okObjectResult);
        }

        [Fact]
        public async Task DeleteProductByIdAsync_ShouldReturnOk()
        {
            //Arrange
            var productFound = new Product
            {
                Id = 5
            };

            _productRepoMock.Setup(x => x.GetByIdAsync(idProductToTest))
               .ReturnsAsync(productFound);
            //Act
            var result = await _productController.DeleteProductByIdAsync(idProductToTest);
            var okObjectResult = (NoContentResult)result;
            //Assert
            Assert.IsType<NoContentResult>(okObjectResult);
        }

        [Fact]
        public async Task UpdateProductByIdAsync_ShouldReturnFail()
        {
            //Arrange
            var productToUpdate = new UpdateProductCommand
            {
                Id = 1,
                Description = "test",
                AgeRestriction = 18,
                Company = "test",
                Name = "test",
                Price = 100
            };
            //Act
            var result = await _productController.UpdateProductByIdAsync(productToUpdate);
            var okObjectResult = (NotFoundObjectResult)result;
            //Assert
            Assert.IsType<NotFoundObjectResult>(okObjectResult);
        }

        [Fact]
        public async Task UpdateProductByIdAsync_ShouldReturnOk()
        {
            var productFoundedById = new Product
            {
                Id = 1,
                Description = "test",
                AgeRestriction = 10,
                Company = "test",
                Name = "test",
                Price = 100
            };

            var productUpdatedById = new Product
            {
                Id = 1,
                Description = "updated",
                AgeRestriction = 18,
                Company = "updated",
                Name = "updated",
                Price = 100
            };

            //Arrange
            var productToUpdate = new UpdateProductCommand
            {
                Id = 1,
                Description = "updated",
                AgeRestriction = 18,
                Company = "updated",
                Name = "updated",
                Price = 100
            };

            _productRepoMock.Setup(x => x.GetByIdAsync(productToUpdate.Id))
               .ReturnsAsync(productFoundedById);

            _productRepoMock.Setup(x => x.UpdateAsync(productUpdatedById))
               .ReturnsAsync(productUpdatedById);
            //Act
            var result = await _productController.UpdateProductByIdAsync(productToUpdate);
            var okObjectResult = (OkObjectResult)result;
            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldReturnOk()
        {
            //Arrange
            var productToCreate = new CreateProductCommand
            {
                Description = "test",
                AgeRestriction = 18,
                Company = "test",
                Name = "test",
                Price = 100
            };

            var newProduct = new Product
            {
                Id=1,
                Description = "test",
                AgeRestriction = 18,
                Company = "test",
                Name = "test",
                Price = 100
            };
            //_loggerMock.Setup(x => x.Map(productToCreate, new Product())).Returns(newProduct);
            _productRepoMock.Setup(x => x.CreateAsync(newProduct))
               .ReturnsAsync(newProduct);
            //Act
            var result = await _productController.CreateProductAsync(productToCreate);
            var okObjectResult = (OkObjectResult)result;
            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
        }
    }
}