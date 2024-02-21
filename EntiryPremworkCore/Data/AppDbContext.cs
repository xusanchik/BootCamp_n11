using EntiryPremworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EntiryPremworkCore.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Productss{ get; set; }
    public DbSet<Market> Markets { get; set; }
}