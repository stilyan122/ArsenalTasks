using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(University))]
        public int UniversityId { get; set; }

        public University University { get; set; } = null!;

        public ICollection<Major> Majors { get; set; } = new List<Major>();
    }
}
