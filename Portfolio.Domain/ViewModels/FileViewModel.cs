using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.ViewModels
{
    public class FileViewModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
