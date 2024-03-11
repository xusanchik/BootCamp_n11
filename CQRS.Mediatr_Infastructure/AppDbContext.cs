using CQRS.Mediatr_Domen.Entity;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Mediatr_Infastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; } 

    }
}
