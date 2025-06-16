using System.ComponentModel.DataAnnotations;
using CC =
    MarketVault.Infrastructure.Constants.Models.CustomerConstants;

namespace MarketVault.Infrastructure.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, MaxLength(CC.MaxNameLength)]
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } 
            = new List<Order>();
    }
}
