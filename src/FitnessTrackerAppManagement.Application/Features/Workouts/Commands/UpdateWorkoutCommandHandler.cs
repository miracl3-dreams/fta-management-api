using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Commands
{
    public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, bool>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public UpdateWorkoutCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _context.Workouts.FindAsync(request.Name);
            if (workout == null) 
                return false;

            workout.Name = request.Name;
            workout.Description = request.Description;
            workout.DurationInMinutes = request.DurationInMinutes;
            workout.CaloriesBurned = request.CaloriesBurned;
            workout.IntensityLevel = request.IntensityLevel;
            workout.ScheduledAt = request.ScheduledAt;
            workout.Status = request.Status;
            workout.UserId = request.UserId;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion Public Methods
    }
}
