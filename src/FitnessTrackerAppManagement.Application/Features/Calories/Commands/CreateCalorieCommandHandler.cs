using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Calories.Commands
{
    public class CreateCalorieCommandHandler : IRequestHandler<CreateCalorieCommand, int>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public CreateCalorieCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> Handle(CreateCalorieCommand request, CancellationToken cancellationToken)
        {
            var calorieEntry = new Domain.Entities.Calorie
            {
                UserId = request.UserId,
                CaloriesConsumed = request.CaloriesConsumed,
                CaloriesBurned = request.CaloriesBurned,
                Description = request.Description
            };

            _context.Calories.Add(calorieEntry);
            await _context.SaveChangesAsync(cancellationToken);

            return calorieEntry.Id; 
        }

        #endregion Public Methods
    }
}
