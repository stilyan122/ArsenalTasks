using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(60)]
        public string? Genre { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [MaxLength(1000)]
        public string? Synopsis { get; set; }

        [MaxLength(300)]
        public string? PosterUrl { get; set; }

        // Navigation (optional, useful for queries)
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
