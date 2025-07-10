using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Commands
{
    public class UpdateCalorieCommandHandler: IRequestHandler<UpdateCalorieCommand, bool>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public UpdateCalorieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(UpdateCalorieCommand request, CancellationToken cancellationToken)
        {
            var calorieEntry = await _context.Calories.FindAsync(request.Id);
            if (calorieEntry == null)
                return false;

            calorieEntry.UserId = request.UserId;
            calorieEntry.CaloriesConsumed = request.CaloriesConsumed;
            calorieEntry.CaloriesBurned = request.CaloriesBurned;
            calorieEntry.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion Public Methods
    }
}
