using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Queries
{
    public class GetAllWorkoutQuery : IRequest<List<WorkoutDto>>
    {
    }
}
