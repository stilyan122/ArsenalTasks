using System.ComponentModel.DataAnnotations;
using SC =
    MarketVault.Infrastructure.Constants.Models.SupplierConstants;

namespace MarketVault.Infrastructure.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required, MaxLength(SC.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(SC.MaxContactNumberLength)]
        public string ContactNumber { get; set; } = null!;

        [Required, MaxLength(SC.MaxEmailLength)]
        public string Email { get; set; } = null!;

        public ICollection<ProductSupplier> ProductSuppliers { get; set; } 
            = new List<ProductSupplier>();
    }
}
