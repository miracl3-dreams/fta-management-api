using MediatR;
using FitnessTrackerAppManagement.Domain.Interfaces;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Commands
{
    public class DeleteCalorieCommandHandler
    {
        #region Fields 
        
        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public DeleteCalorieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(DeleteCalorieCommand request, CancellationToken cancellationToken)
        {
            var calorieEntry = await _context.Calories.FindAsync(request.Id);
            if (calorieEntry == null)
                return false;

            _context.Calories.Remove(calorieEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion Public Methods
    }
}
