using System.ComponentModel.DataAnnotations;

namespace fullwoodweb.Models
{
    public class CowViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool OnFarm { get; set; }

        [Required]
        public int CowNumber { get; set; }

        [Required]
        public string CowName { get; set; } = string.Empty;

        public DateTime RegisteredDate { get; set; }
    }
}
