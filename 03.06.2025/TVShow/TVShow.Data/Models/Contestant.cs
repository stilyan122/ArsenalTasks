using System.ComponentModel.DataAnnotations;

namespace TVShow.Data.Models
{
    public class Contestant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на участника е задължително.")]
        [MaxLength(200, ErrorMessage = "Името не може да надвишава 200 символа.")]
        public string FullName { get; set; }

        [Range(1, 120, ErrorMessage = "Възрастта трябва да бъде между 1 и 120.")]
        public int? Age { get; set; }

        [EmailAddress(ErrorMessage = "Невалиден имейл формат.")]
        public string ContactEmail { get; set; }

        [Phone(ErrorMessage = "Невалиден телефонен номер.")]
        public string PhoneNumber { get; set; }

        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }
}
