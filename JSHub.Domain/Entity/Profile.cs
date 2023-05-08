using JSHub.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSHub.Domain.Entity
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public Employment? Employment { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string? AboutMe { get; set; }
        public string? Experience { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<SpecialityBox> Specializations { get; set; }
    }
}
