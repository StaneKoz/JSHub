
namespace JSHub.Domain.Entity
{
    public class Vacansy
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Name { get; set; }
    }
}
