using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JSHub.Domain.Enum
{
    public enum Speciality
    {
        [Display(Name = "Веб-дизайн")]
        WebDesign = 0,
        [Display(Name = "Арт-директор")]
        ArtDirector = 1,
        [Display(Name = "Дизайн анимаций")]
        AnimationDesign = 2,
    }
}
