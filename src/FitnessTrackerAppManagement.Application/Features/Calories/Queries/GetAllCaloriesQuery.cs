using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Queries
{
    public class GetAllCaloriesQuery : IRequest<List<CalorieDto>>
    {
    }
}
