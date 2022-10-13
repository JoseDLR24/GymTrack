namespace GymTrack.Models
{
    public class WorkOut
    {
        public int WorkoutId { get; set; }

        // references for Category foreign key and Category Model
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // references for Exercise Details foreign Key and Model
        public int ExerciseDetailId { get; set; }
        public ExerciseDetail? ExerciseDetail { get; set; }
    }
}
