using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApp.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public ProductType Type { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [NotMapped]
        public string Code
        {
            get
            {
                var namePart = (Name ?? string.Empty);
                namePart = namePart.Length >= 2 ? namePart[..2] : namePart;

                var typeStr = Type.ToString(); 
                var typePart = typeStr.Length >= 3 ? typeStr[..3] : typeStr;

                return $"{namePart}{typePart}{Id:D4}";
            }
        }
    }
}
