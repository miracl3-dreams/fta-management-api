using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Queries
{
    public class GetAllFoodQuery : IRequest<List<FoodDto>>
    {
    }
}
