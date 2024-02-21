using EntiryPremworkCore.Data;
using EntiryPremworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EntiryPremworkCore.Repositories.Emplamed;


public class ProductRepository:IProduct
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return  await _context.Productss.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        var find =  await _context.Productss.FirstOrDefaultAsync( x => x.Id == id);
        return find;
    }

    public async Task<Product> AddProduct(Product product)
    {
         _context.Productss.Add(product);
         await _context.SaveChangesAsync();
         return product;
        
    }

    public async Task<Product> UpdateProduct(int id, Product product)
    {
       var find = await _context.Productss.FirstOrDefaultAsync(x => x.Id == id); 
       find.Name = product.Name;
       find.Price = product.Price;
       await _context.SaveChangesAsync();
       return find;
    }

    public async Task DeleteProduct(int id)
    {
        var find = await _context.Productss.FirstOrDefaultAsync(x => x.Id == id);
        _context.Productss.Remove(find);
        await _context.SaveChangesAsync();
        
    }

    public async Task<IEnumerable<Market>> GetMarkets()
    {
        return  await _context.Markets.ToListAsync();
    }
}