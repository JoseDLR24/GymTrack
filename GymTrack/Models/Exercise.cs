namespace GymTrack.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        public string? ExerciseName { get; set; }
        public List<ExerciseDetail>? ExerciseDetails { get; set; }

        // ref to parent model, category, one category can have many exercises
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        
    }
}
