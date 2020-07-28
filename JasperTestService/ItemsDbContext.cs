using Jasper.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JasperTestService
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapEnvelopeStorage();

            modelBuilder.Entity<Item>(map =>
            {
                map.ToTable("items");
                map.HasKey(x => x.Id);
                map.Property(x => x.Name);
            });
        }
    }
}