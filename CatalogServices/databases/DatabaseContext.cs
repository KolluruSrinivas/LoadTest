using Microsoft.EntityFrameworkCore;

namespace CatalogService.databases
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories {  get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
