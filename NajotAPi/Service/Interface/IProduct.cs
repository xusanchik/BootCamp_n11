using NajotAPi.Models;

namespace NajotAPi.Service.Interface;

public interface IProduct
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<Product> Create(Product product);
    Task<Product> Update(Guid id, Product product);
    Task Delete(Guid id);
    
}