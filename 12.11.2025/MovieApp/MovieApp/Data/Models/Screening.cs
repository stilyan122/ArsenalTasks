using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.Models
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required, MaxLength(40)]
        public string Hall { get; set; } = "Hall 1";

        [Range(0, 100)]
        public decimal Price { get; set; } = 12.00m;
    }
}
