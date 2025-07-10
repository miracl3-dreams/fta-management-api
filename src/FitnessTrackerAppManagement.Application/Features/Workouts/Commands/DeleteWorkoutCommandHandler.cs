using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Workouts.Commands
{
    public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand, bool>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public DeleteWorkoutCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _context.Workouts.FindAsync(request.Name);
            if (workout == null)
                return false;
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion Public Methods
    }
}
