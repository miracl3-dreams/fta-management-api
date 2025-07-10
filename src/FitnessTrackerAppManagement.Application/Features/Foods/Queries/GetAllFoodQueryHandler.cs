using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Queries
{
    public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, List<FoodDto>>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public GetAllFoodQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<List<FoodDto>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
        {
            return await _context.Foods
                .AsNoTracking()
                .Select(f => new FoodDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Protein = f.Protein,
                    Carbohydrates = f.Carbohydrates,
                    Fats = f.Fats,
                    CreatedAt = f.CreatedAt
                })
                .ToListAsync(cancellationToken);
        }

        #endregion Public Methods
    }
}
