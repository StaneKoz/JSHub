using JSHub.Domain.Enum;

namespace JSHub.Domain.Entity
{
    public class SpecialityBox
    {
        public int Id { get; set; }
        public Speciality Name { get; set; }
        public ICollection<Profile> Profiles { get; set; }

    }
}
