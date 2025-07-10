namespace FitnessTrackerAppManagement.Application.Common.Results
{
    public class WorkoutResult
    {
        #region Properties

        public bool Success { get; set; }
        public string? Message { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string IntensityLevel { get; set; } = string.Empty;
        public string Status { get; set; } = "Planned";

        #endregion Properties
    }
}
