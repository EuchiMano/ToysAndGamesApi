using ToysAndGames.DataAccess.Data;
using ToysAndGames.Model.Products;

namespace ToysAndGames.DataAccess
{
    public static class SeedData
    {
        public static List<Product> Products()
        {
            int id = 1;

            var products = new List<Product>()
            {
                new Product() {
                    Id = id++,
                    Name = "Barbie Developer",
                    AgeRestriction = 12,
                    Price = 25.99m,
                    Company = "Mattel",
                    Description = "Lorem impsum..." },
                new Product() {
                    Id = id++,
                    Name = "xyc",
                    AgeRestriction = 4,
                    Price = 75.50m,
                    Company = "Marvel" },
                new Product(){
                    Id = id++,
                    Name = "abc",
                    AgeRestriction = 18,
                    Price = 99.99m,
                    Company = "Nintendo" },
            };

            return products;
        }

        public static void PopulateTestData(ApplicationDbContext dbContext)
        {
            dbContext.Products.AddRange(Products());
            dbContext.SaveChanges();
        }
    }
}