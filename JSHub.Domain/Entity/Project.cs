
namespace Portfolio.Domain.Entity
{
    public class Project
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }

    }
}
