using Microsoft.EntityFrameworkCore;
using NajotAPi.Data;
using NajotAPi.Service.Interface;

namespace NajotAPi.Service.Repository;

public class Product : IProduct
{
    private readonly AppDbContext _dbContext;
    private IProduct _productImplementation;

    public Product(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<List<Models.Product>> GetAll()
    {
        var result = _dbContext.Products.ToListAsync();  
        return result;
    }

    public Task<Models.Product> GetById(Guid id)
    {
        var find = _dbContext.Products.FirstOrDefault(find => find.id == id);
        return Task.FromResult(find);
    }

    public  Task<Models.Product> Create(Models.Product product)
    {
        var newmodel = new Models.Product();
        newmodel.name = product.name;
        newmodel.description = product.description;
        newmodel.price = product.price;
        _dbContext.Products.Add(newmodel);
        _dbContext.SaveChanges();
        return Task.FromResult(newmodel);
        
        
    }

    public Task<Models.Product> Update(Guid id, Models.Product product)
    {
        var findmodel = _dbContext.Products.FirstOrDefault(p => p.id == id);
        findmodel.name = product.name;
        findmodel.description = product.description;
        findmodel.price = product.price;
        _dbContext.SaveChanges();
        return Task.FromResult(findmodel);
    } 

    public Task Delete(Guid id)
    {
        var findmodel = _dbContext.Products.FirstOrDefault(p => p.id == id);
        _dbContext.Products.Remove(findmodel);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}