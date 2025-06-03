using System.ComponentModel.DataAnnotations;

namespace TVShow.Data.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието на викторината е задължително.")]
        [MaxLength(100, ErrorMessage = "Заглавието не може да надвишава 100 символа.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Връзката към предаването (ShowId) е задължителна.")]
        public int ShowId { get; set; }

        [MaxLength(500, ErrorMessage = "Описанието на викторината не може да надвишава 500 символа.")]
        public string Description { get; set; }

        public Show Show { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
