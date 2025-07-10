using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Queries
{
    public class GetWorkoutByIdQueryHandler : IRequestHandler<GetWorkoutByIdQuery, WorkoutDto?>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetWorkoutByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<WorkoutDto?> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Workouts
                .Where(w => w.Id == request.Id)
                .Select(w => new WorkoutDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    DurationInMinutes = w.DurationInMinutes,
                    CaloriesBurned = w.CaloriesBurned,
                    IntensityLevel = w.IntensityLevel,
                    ScheduledAt = w.ScheduledAt,
                    Status = w.Status,
                    UserId = w.UserId
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        #endregion Public Methods
    }
}
