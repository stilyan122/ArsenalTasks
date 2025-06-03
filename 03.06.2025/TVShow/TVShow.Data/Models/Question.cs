using System.ComponentModel.DataAnnotations;

namespace TVShow.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Текстът на въпроса е задължителен.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Опция A е задължителна.")]
        public string OptionA { get; set; }

        [Required(ErrorMessage = "Опция B е задължителна.")]
        public string OptionB { get; set; }

        [Required(ErrorMessage = "Опция C е задължителна.")]
        public string OptionC { get; set; }

        [Required(ErrorMessage = "Опция D е задължителна.")]
        public string OptionD { get; set; }

        [Required(ErrorMessage = "Коректният отговор е задължителен.")]
        [RegularExpression("A|B|C|D", ErrorMessage = "Коректният отговор трябва да бъде A, B, C или D.")]
        public string CorrectAnswer { get; set; }

        [Required(ErrorMessage = "Връзката към викторината (QuizId) е задължителна.")]
        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}
