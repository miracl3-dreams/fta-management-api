using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Commands
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, bool>
    {
        #region Fields 

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public UpdateFoodCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _context.Foods.FindAsync(request.Name);
            if (food == null)
                return false;

            food.Name = request.Name;
            food.Calories = request.Calories;
            food.Protein = request.Protein;
            food.Carbohydrates = request.Carbohydrates;
            food.Fats = request.Fats;
            food.CreatedAt = request.CreatedAt;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion Public Methods
    }
}