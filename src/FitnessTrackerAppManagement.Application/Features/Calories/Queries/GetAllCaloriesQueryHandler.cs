using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Queries
{
    public class GetAllCaloriesQueryHandler : IRequestHandler<GetAllCaloriesQuery, List<CalorieDto>>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetAllCaloriesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<List<CalorieDto>> Handle(GetAllCaloriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Calories
                .Select(c => new CalorieDto
            {
                Id = c.Id,
                UserId = c.UserId,
                CaloriesConsumed = c.CaloriesConsumed,
                CaloriesBurned = c.CaloriesBurned,
                Description = c.Description
            })
            .OrderBy(c => c.UserId)
            .ToListAsync(cancellationToken);
        }
        #endregion Public Methods
    }
}
