using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Model.Interfaces;
using ToysAndGames.Model.Products;

namespace ToysAndGames.Api.Controllers.Products
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] CreateProductCommand command)
        {
            var newProduct = _mapper.Map<Product>(command);
            var newProductCreated = await _productRepository.CreateAsync(newProduct);
            return Ok(newProductCreated);
        }

        [HttpGet("/api/[controller]/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var productFound = await _productRepository.GetById(productId);
            if(productFound is null) return NotFound();
            return Ok(productFound);
        }
    }
}