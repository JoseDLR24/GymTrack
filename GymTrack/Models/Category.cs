using System.ComponentModel.DataAnnotations;

namespace GymTrack.Models
    {
        public class Category
        {
        [Required]
            public int? CategoryId { get; set; }

            [Required]
            [MaxLength(50)]
            public string? Name { get; set; }

        // ref list of child model
        public List<Exercise>? Exercises { get; set; }
        }
    }
