using EntiryPremworkCore.Models;
using EntiryPremworkCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntiryPremworkCore.Controllers;

 [Route("api/[controller] [action]")]
[ApiController]
public class MarketController : ControllerBase
{
 private readonly IMarket _market;

 public MarketController(IMarket market)
 {
  _market = market;
 }
 [HttpGet]
 public async Task<ActionResult> GetMarkets() => Ok(await _market.GettMarket());
 [HttpGet("{id}")]
 public async Task<ActionResult> GetMarket(int id) => Ok(await _market.GetMarketById(id));
 [HttpPost]
 public async Task<ActionResult> PostMarket(Market market) => Ok(await _market.AddMarket(market));
 [HttpPut]
 public async Task<ActionResult> PutMarket(int id,  Market market) => Ok(await _market.UpdateMarket(id,market));

 [HttpDelete("{id}")]
 public async Task<ActionResult> DeleteMarket(int id)
 {
  await _market.DeleteMarket(id);
  return Ok();
 }



}