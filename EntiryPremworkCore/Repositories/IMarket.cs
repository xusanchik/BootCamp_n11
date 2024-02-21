using EntiryPremworkCore.Models;

namespace EntiryPremworkCore.Repositories;


public interface IMarket
{
    Task <List<Market>> GettMarket();
    Task<Market> GetMarketById(int id);
    Task<Market> AddMarket(Market market);
    Task<Market> UpdateMarket(int id, Market market);
    Task DeleteMarket(int id);
    

   
}

