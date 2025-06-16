using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketVault.Infrastructure.Models
{
    public class ProductSupplier
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal DeliveryPrice { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
