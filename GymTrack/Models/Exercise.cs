namespace GymTrack.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        // reference to foreign key for category table
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
