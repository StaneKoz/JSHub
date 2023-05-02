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
        //public List<Speciality>? Speciality { get; set; }
        public string Speciality { get; set; }
        public string PhoneNumber { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string AboutMe { get; set; }
        [NotMapped]
        public ICollection<Speciality> Specialities { get; set; }
    }
}
