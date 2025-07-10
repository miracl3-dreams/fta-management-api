using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Queries
{
    public class GetCalorieByIdQuery : IRequest<CalorieDto>
    {
        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}
