using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Commands
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, string>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public CreateFoodCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<string> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = new Domain.Entities.Food
            {
                Name = request.Name,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats,
                CreatedAt = DateTime.UtcNow
            };

            _context.Foods.Add(food);
            await _context.SaveChangesAsync(cancellationToken);

            return food.Name;
        }

        #endregion Public Methods
    }
}
