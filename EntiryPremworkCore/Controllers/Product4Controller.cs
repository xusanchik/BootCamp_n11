using EntiryPremworkCore.Models;
using EntiryPremworkCore.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntiryPremworkCore.Controllers;

[Route("api/[controller] [action]")]
[ApiController]
public class Product4Controller : ControllerBase
{
    private readonly IProduct _product;
    public Product4Controller(IProduct product)
    {
        _product = product;
    }
    
    [HttpGet]
    public async Task<ActionResult>  GetProducts() => Ok(await _product.GetProducts());
    [HttpGet("{id}")]
    public async Task<ActionResult> GetProduct(int id) => Ok(await _product.GetProductById(id));
    [HttpPost]
    public async Task<ActionResult> PostProduct(Product product) => Ok(await _product.AddProduct(product));
    [HttpPut]
    public async Task<ActionResult> PutProduct(int id,  Product product) => Ok(await _product.UpdateProduct(id,product));

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await _product.DeleteProduct(id);
        return Ok();
    }
    
    
    
    
}