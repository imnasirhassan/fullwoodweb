using System.ComponentModel.DataAnnotations;

namespace fullwoodweb.Models
{
    public class ImportViewModel
    {
        [Required]
        public IFormFile? JsonFile { get; set; }
    }
}
