using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToysAndGames.Model.Products;

namespace ToysAndGames.DataAccess.FluentConfig
{
    public class FluentProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.AgeRestriction);
            builder.HasCheckConstraint("CK_Products_AgeRestriction", "[AgeRestriction] >= 0 AND [AgeRestriction] <= 100");
            builder.Property(p => p.Company).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).IsRequired();
            builder.HasCheckConstraint("CK_Products_Price", "[Price] >= 1 AND [Price] <= 1000");
            builder.HasData(SeedData.Products());
        }
    }
}