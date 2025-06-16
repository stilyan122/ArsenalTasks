using System.ComponentModel.DataAnnotations;
using CC =
    MarketVault.Infrastructure.Constants.Models.CategoryConstants;

namespace MarketVault.Infrastructure.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(CC.MaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = 
            new List<Product>();
    }
}
