﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Repositories.ProductRepository;
using RealEstate.Api.Dtos.ProductDtos;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            List<ResultProductDto> products = await _productRepository.GetAllProductAsync();
            return Ok(products);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            List<ResultProductWithCategoryDto> productsWithCategory = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(productsWithCategory);
        }
    }
}
