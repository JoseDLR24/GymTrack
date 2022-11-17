using System.ComponentModel.DataAnnotations;

namespace GymTrack.Models
{
    public class ExerciseDetail
    {
        public int ExerciseDetailId { get; set; }

        // reference to foreign key from Exercise class
        [Required]
        [Display(Name = "Exercise")]
        public int ExerciseId { get; set; }  
        // ref to Exercise Model
        public Exercise? Exercise { get; set; }

        [Range(1, 999)]
        public int Sets { get; set; }
        [Range(1, 999)]
        public int Reps { get; set; }

        [Range (0, 999)]
        [Display(Name = "Weight (kg)")]
        public int Weight { get; set; }
    }
}
