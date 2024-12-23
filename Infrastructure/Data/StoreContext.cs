using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
    {
        public required DbSet<Product> Products { get; set; }
        public required DbSet<ProductType> ProductType { get; set; }
        public required DbSet<ProductBrand> ProductBrand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}