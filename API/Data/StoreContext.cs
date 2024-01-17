using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext // Inherit from DbContext to access Entity Framework Core features
    {
        public StoreContext(DbContextOptions options) : base(options) // Pass the options to the base class
        {
        }

        public DbSet<Product> Products { get; set; } // Expose the Products table as a DbSet property
    }
}