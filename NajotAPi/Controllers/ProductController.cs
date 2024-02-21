using Microsoft.AspNetCore.Mvc;
using NajotAPi.Service.Interface;

namespace NajotAPi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProduct   _product;
    public ProductController(IProduct product)
    {
        _product = product;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _product.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _product.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Models.Product product)
    {
        var result = await _product.Create(product);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Models.Product product)
    {
        var result = await _product.Update(id, product);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _product.Delete(id);
        return Ok();
    }

}