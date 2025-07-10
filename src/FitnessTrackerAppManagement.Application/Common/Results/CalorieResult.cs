namespace FitnessTrackerAppManagement.Application.Common.Results
{
    public class CalorieResult
    {
        #region Properties

        public bool Success { get; set; }
        public string? Message { get; set; }
        public Guid UserId { get; set; }
        public int CaloriesConsumed { get; set; }
        public int CaloriesBurned { get; set; }
        public string? Description { get; set; }

        #endregion Properties
    }
}
