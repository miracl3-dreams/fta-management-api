namespace FitnessTrackerAppManagement.Application.Common.DTOs.Responses
{
    public class CalorieDto
    {  
        #region Properties

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CaloriesConsumed { get; set; }
        public int CaloriesBurned { get; set; }
        public string? Description { get; set; }

        #endregion Properties
    }
}
