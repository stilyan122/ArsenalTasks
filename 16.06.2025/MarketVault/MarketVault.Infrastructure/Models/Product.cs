using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PC =
    MarketVault.Infrastructure.Constants.Models.ProductConstants;

namespace MarketVault.Infrastructure.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(PC.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ProductOrder> ProductOrders { get; set; } = 
            new List<ProductOrder>();

        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = 
            new List<ProductSupplier>();
    }
}
