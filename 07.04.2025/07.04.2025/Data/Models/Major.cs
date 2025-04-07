using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Faculty))]
        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; } = null!;
    }
}
