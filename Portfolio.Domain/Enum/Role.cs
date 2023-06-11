using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Entity
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Админ")]
        Админ = 1
    }
}
