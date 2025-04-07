using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
