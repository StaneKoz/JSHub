using Portfolio.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.ViewModels.Profile
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Укажите возраст")]
        [Range(0, 150, ErrorMessage = "Диапазон возрста: 16 - 90 лет")]
        public short Age { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$",
            ErrorMessage = "Неверный формат номера телефона")]
        public string PhoneNumber { get; set; }
        public Employment? Employment { get; set; }
        public string? Email { get; set; }
        public string? AboutMe { get; set; }
        public string? Experience { get; set; }
    }
}
