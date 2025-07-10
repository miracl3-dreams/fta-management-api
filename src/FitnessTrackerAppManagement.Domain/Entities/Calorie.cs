namespace FitnessTrackerAppManagement.Domain.Entities
{
    public class Calorie
    {
        #region Properties

        public int Id { get; set; }

        // User relationship
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        // Calorie details
        public int CaloriesConsumed { get; set; }
        public int CaloriesBurned { get; set; }
        public string? Description { get; set; }

        // Food relationship
        public int? FoodId { get; set; }
        public Food? Food { get; set; }

        // Workout relationship
        public int? WorkoutId { get; set; }
        public Workout? Workout { get; set; }

        // TODO: Navigation property for CalorieEntry (if applicable in future)

        #endregion Properties
    }
}
