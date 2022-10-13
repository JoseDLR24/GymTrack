using System.ComponentModel.DataAnnotations;

namespace GymTrack.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

    }
}
