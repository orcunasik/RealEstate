using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Repositories.ProductRepository;
using RealEstate.Api.Dtos.ProductDtos;

namespace RealEstate.Api.Controllers;

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

    [HttpGet("LastProducts")]
    public async Task<IActionResult> LastProducts()
    {
        List<ResultProductWithCategoryDto> lastProducts = await _productRepository.GetLastProductsAsync();
        return Ok(lastProducts);
    }

    [HttpPatch("ProductDealOfTheDayStatusTrue/{id}")]
    public async Task<IActionResult> ProductDealOfTheDayStatusTrue(int id)
    {
        await _productRepository.ProductDealOfTheDayStatusChangeToTrueAsync(id);
        return Ok("İlanın Durumu Aktif olarak güncellendi!");
    }

    [HttpPatch("ProductDealOfTheDayStatusFalse/{id}")]
    public async Task<IActionResult> ProductDealOfTheDayStatusFalse(int id)
    {
        await _productRepository.ProductDealOfTheDayStatusChangeToFalseAsync(id);
        return Ok("İlanın Durumu Pasif olarak güncellendi!");
    }
}