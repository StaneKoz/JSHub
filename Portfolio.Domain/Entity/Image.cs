

namespace Portfolio.Domain.Entity
{
    public class Image
    {
        public long Id { get; set; }
        public string Name { get; set; } = "avatar-default.png";
        public string Path { get; set; } = "/img/avatar-default.png";

        public override bool Equals(object? obj)
        {
            if (obj is Image image)
            {
                return image.Name == Name && image.Path == Path;
            }

            return false;
        }
    }
}
