using Microsoft.EntityFrameworkCore;
using ToysAndGames.DataAccess.FluentConfig;
using ToysAndGames.Model.Products;

namespace ToysAndGames.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FluentProductConfig());
        }
    }
}