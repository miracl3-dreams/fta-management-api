using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Commands
{
    public class CreateWorkoutCommand : IRequest<int>
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public string IntensityLevel { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }

        #endregion Properties
    }
}
