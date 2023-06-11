
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Entity
{
    public class Project
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        [NotMapped]
        public ICollection<string> Images { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
    }
}
