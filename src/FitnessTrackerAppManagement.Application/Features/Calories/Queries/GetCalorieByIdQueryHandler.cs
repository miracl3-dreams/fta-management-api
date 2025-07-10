using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Queries
{
    public class GetCalorieByIdQueryHandler : IRequestHandler<GetCalorieByIdQuery, CalorieDto?>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetCalorieByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<CalorieDto?> Handle(GetCalorieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Calories
                .Where(c => c.Id == request.Id)
                .Select(c => new CalorieDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    CaloriesConsumed = c.CaloriesConsumed,
                    CaloriesBurned = c.CaloriesBurned,
                    Description = c.Description
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        #endregion Public Methods
    }
}
