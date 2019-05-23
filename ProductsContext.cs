using Microsoft.EntityFrameworkCore;

namespace netcore_postgre
{
    public class ProductsContext: DbContext
    {
        public DbSet<Product> Products {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(@"Server=localhost;Database=myproductsdb;Username=postgres;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}