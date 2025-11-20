using System.ComponentModel.DataAnnotations;

namespace EmployeesDepartments.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();    
    }
}
