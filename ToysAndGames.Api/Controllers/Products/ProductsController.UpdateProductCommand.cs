using System.ComponentModel.DataAnnotations;

namespace ToysAndGames.Api.Controllers.Products
{
    public class UpdateProductCommand
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string? Description { get; set; }
        [Range(0, 100)]
        public int? AgeRestriction { get; set; }
        [Required, MaxLength(50)]
        public string Company { get; set; } = null!;
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
    }
}
