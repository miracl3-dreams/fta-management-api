using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Queries
{
    public class GetWorkoutByIdQuery : IRequest<WorkoutDto?>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}
