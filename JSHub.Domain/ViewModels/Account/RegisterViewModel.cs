
using JSHub.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace JSHub.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [RegularExpression(pattern: @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
            ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен иметь длину минимум в 8 символов")]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
