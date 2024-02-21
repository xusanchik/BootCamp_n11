﻿using Microsoft.EntityFrameworkCore;
using NajotAPi.Models;

namespace NajotAPi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<MarketPlase> MarketPlases { get; set; } 
    }
}
