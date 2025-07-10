namespace FitnessTrackerAppManagement.Application.Common.DTOs.Responses
{
    public class WorkoutDto
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string IntensityLevel { get; set; } = string.Empty;
        public string Status { get; set; } = "Planned";
        public Guid UserId { get; set; }

        #endregion Properties
    }
}
