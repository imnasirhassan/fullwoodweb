using System.ComponentModel.DataAnnotations;

namespace fullwood.domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
