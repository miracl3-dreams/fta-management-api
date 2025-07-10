using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Commands
{
    public class DeleteCalorieCommand : IRequest<bool>
    {
        #region Properties

        public int Id { get; set; }
        public Guid UserId { get; set; }

        #endregion Properties
    }
}
