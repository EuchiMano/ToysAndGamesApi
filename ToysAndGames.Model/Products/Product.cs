namespace ToysAndGames.Model.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? AgeRestriction { get; set; }
        public string Company { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Image { get; set; }
    }
}