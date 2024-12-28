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

            // if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            // {
            //     foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //     {
            //         var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

            //         foreach (var property in properties)
            //         {
            //             modelBuilder.Entity(entityType.Name).Property(property.Name)
            //             .HasConversion<double>();
            //         }
            //     }
            // }
        }
    }
}