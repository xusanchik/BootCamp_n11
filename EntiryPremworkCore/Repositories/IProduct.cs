using EntiryPremworkCore.Models;

namespace EntiryPremworkCore.Repositories;

public interface IProduct
{
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id,Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Market>> GetMarkets();
    
}