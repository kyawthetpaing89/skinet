using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
    {
        public required DbSet<Product> Products { get; set; }
    }
}