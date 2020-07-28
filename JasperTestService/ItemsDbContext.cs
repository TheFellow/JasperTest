using Microsoft.EntityFrameworkCore;

namespace JasperTestService
{
    public class ItemsDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}