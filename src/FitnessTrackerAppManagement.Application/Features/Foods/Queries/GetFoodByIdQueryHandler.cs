using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Queries
{
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodDto?>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetFoodByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<FoodDto?> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Foods
                .Where(f => f.Id == request.Id)
                .Select(f => new FoodDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Protein = f.Protein,
                    Carbohydrates = f.Carbohydrates,
                    Fats = f.Fats,
                    CreatedAt = f.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        #endregion Public Methods
    }
}
