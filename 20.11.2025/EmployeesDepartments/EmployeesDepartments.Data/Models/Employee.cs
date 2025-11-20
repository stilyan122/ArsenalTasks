using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesDepartments.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]                        
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        
        public Department? Department { get; set; }
    }
}
