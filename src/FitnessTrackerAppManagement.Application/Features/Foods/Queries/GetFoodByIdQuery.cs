using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Queries
{
    public class GetFoodByIdQuery : IRequest<FoodDto?>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}
