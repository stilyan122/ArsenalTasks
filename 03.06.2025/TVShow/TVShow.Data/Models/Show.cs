using System.ComponentModel.DataAnnotations;

namespace TVShow.Data.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на предаването е задължително.")]
        [MaxLength(100, ErrorMessage = "Името не може да надвишава 100 символа.")]
        public string Name { get; set; }

        public DateTime? AirDate { get; set; }

        [MaxLength(500, ErrorMessage = "Описанието не може да надвишава 500 символа.")]
        public string Description { get; set; }

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

        public ICollection<Contestant> Contestants { get; set; } = new List<Contestant>();
    }
}
