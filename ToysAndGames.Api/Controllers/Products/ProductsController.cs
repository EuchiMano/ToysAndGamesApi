﻿using AutoMapper;
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

        [HttpPost("/api/[controller]/")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request)
        {
            var newProduct = _mapper.Map(request, new Product());
            await _productRepository.CreateAsync(newProduct);
            return Ok(newProduct);
        }

        [HttpGet("/api/[controller]/")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var productFound = await _productRepository.GetAllAsync();
            return Ok(productFound);
        }

        [HttpDelete("/api/[controller]/{productId}")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromRoute] int productId)
        {
            var productFound = await _productRepository.GetByIdAsync(productId);
            if (productFound is null) return NotFound();

            await _productRepository.DeleteAsync(productFound);
            return NoContent();
        }

        [HttpPut("/api/[controller]")]
        public async Task<IActionResult> UpdateProductByIdAsync([FromBody] UpdateProductCommand request)
        {
            var productFound = await _productRepository.GetByIdAsync(request.Id);
            if (productFound is null) return NotFound();

            _mapper.Map(request, productFound);
            await _productRepository.UpdateAsync(productFound);
            return Ok(productFound);
        }
    }
}