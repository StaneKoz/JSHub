using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JSHub.Domain.Entity
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Админ")]
        Админ = 1
    }
}
