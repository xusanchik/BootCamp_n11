using EntiryPremworkCore.Data;
using EntiryPremworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EntiryPremworkCore.Repositories.Emplamed;

public class MarketRepository:IMarket
{
    private readonly AppDbContext   _dbContext;
    public MarketRepository( AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Market>> GettMarket()
    {
        return await _dbContext.Markets.ToListAsync();
    }

    public async Task<Market> GetMarketById(int id)
    {
        var find = await _dbContext.Markets.FirstOrDefaultAsync(x => x.Id == id);
        return find;
    }

    public async Task<Market> AddMarket(Market market)
    {
        _dbContext.Markets.Add(market);
        await _dbContext.SaveChangesAsync();
        return market;
    }

    public async Task<Market> UpdateMarket(int id, Market market)
    {
        var find = await _dbContext.Markets.FirstOrDefaultAsync(x => x.Id == id);
        find.Name = market.Name;
        find.Description = market.Description;
        _dbContext.Markets.Update(find);
        await _dbContext.SaveChangesAsync();
        return find;
    }

    public async Task DeleteMarket(int id)
    {
        var find = await _dbContext.Markets.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Markets.Remove(find);
        await _dbContext.SaveChangesAsync();
        
    }
}