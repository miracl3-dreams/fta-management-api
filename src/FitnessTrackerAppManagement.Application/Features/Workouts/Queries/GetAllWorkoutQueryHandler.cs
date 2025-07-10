using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Queries
{
    public class GetAllWorkoutQueryHandler : IRequestHandler<GetAllWorkoutQuery, List<WorkoutDto>>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetAllWorkoutQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<List<WorkoutDto>> Handle(GetAllWorkoutQuery request, CancellationToken cancellationToken)
        {
            return await _context.Workouts
                .AsNoTracking()
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
                .ToListAsync(cancellationToken);
        }

        #endregion Public Methods

    }
}
