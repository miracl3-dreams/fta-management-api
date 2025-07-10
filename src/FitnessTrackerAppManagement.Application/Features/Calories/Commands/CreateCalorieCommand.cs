using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Commands
{
    public class CreateCalorieCommand : IRequest<int>
    {
        #region Properties

        public Guid UserId { get; set; }
        public int CaloriesConsumed { get; set; }
        public int CaloriesBurned { get; set; }
        public string? Description { get; set; }

        #endregion
    }
}
