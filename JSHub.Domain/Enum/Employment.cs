using System.ComponentModel.DataAnnotations;

namespace JSHub.Domain.Enum
{
    public enum Employment
    {
        [Display(Name = "Полная занятость")]
        Full = 0,
        [Display(Name = "Частичная занятость")]
        PartTime = 1,
        [Display(Name = "Временная занятость")]
        Temporary = 2,
    }
}
