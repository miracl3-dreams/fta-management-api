namespace FitnessTrackerAppManagement.Application.Common.DTOs.Responses
{
    public class CalorieSummaryDto
    {
        public DateTime Date { get; set; }
        public int TotalConsumed { get; set; }
        public int TotalBurned { get; set; }
        public int NetCalories { get; set; }
    }
}
