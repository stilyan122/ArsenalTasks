using System.ComponentModel.DataAnnotations;
using EC =
    MarketVault.Infrastructure.Constants.Models.EmployeeConstants;

namespace MarketVault.Infrastructure.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, MaxLength(EC.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(EC.MaxPositionLength)]
        public string Position { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
