using NajotAPi.Models;

namespace NajotAPi.Service.Interface;


public interface IMarketPlace
{
    Task<List<MarketPlase>> GetAll();
    Task<MarketPlace> GetById<MarketPlace>(Guid id);
    Task<MarketPlase> Create(MarketPlase marketPlace);
    Task<MarketPlase> Update(Guid id ,  MarketPlase marketPlace);
    Task Delete(Guid id);
}