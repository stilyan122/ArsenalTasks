using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models
{
    public class EditPriceViewModel
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
