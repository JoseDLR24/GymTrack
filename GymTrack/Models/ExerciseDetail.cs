using System.ComponentModel.DataAnnotations;

namespace GymTrack.Models
{
    public class ExerciseDetail
    {
        public int ExerciseDetailId { get; set; }

        // reference to foreign key from Exercise class
        public int ExerciseId { get; set; }  
        // ref to Exercise Model
        public Exercise? Exercise { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }

        [Range (0, 999)]
        public int Weight { get; set; }
    }
}
