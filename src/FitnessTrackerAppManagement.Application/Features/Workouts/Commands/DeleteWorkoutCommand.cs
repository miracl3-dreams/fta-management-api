using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Commands
{
    public class DeleteWorkoutCommand : IRequest<bool>
    {
        #region Properties 

        public string Name { get; set; }

        #endregion Properties
    }
}
