using FitnessTrackerAppManagement.Application.Common.DTOs.Requests;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Common.Interfaces;
using FitnessTrackerAppManagement.Domain.Entities;
using FitnessTrackerAppManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Infrastructure.Services
{
    public class FoodService : IFoodService
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Constructor

        public FoodService(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<FoodDto> CreateFoodAsync(FoodCreateRequest request)
        {
            var food = new Food
            {
                Name = request.Name,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats
            };

            _context.Foods.Add(food);
            await _context.SaveChangesAsync(CancellationToken.None);

            return new FoodDto
            {
                Id = food.Id,
                Name = food.Name,
                Calories = food.Calories,
                Protein = food.Protein,
                Carbohydrates = food.Carbohydrates,
                Fats = food.Fats
            };
        }

        public async Task<List<FoodDto>> GetAllFoodsAsync()
        {
            return await _context.Foods
                .Select(f => new FoodDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Protein = f.Protein,
                    Carbohydrates = f.Carbohydrates,
                    Fats = f.Fats
                })
                .ToListAsync();
        }

        public async Task<FoodDto?> GetFoodByIdAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return null;

            return new FoodDto
            {
                Id = food.Id,
                Name = food.Name,
                Calories = food.Calories,
                Protein = food.Protein,
                Carbohydrates = food.Carbohydrates,
                Fats = food.Fats,
            };
        }

        public async Task<bool> UpdateFoodAsync(int id, FoodUpdateRequest request)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return false;

            food.Name = request.Name;
            food.Calories = request.Calories;
            food.Protein = request.Protein;
            food.Carbohydrates = request.Carbohydrates;
            food.Fats = request.Fats;

            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<bool> DeleteFoodAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null) return false;

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        #endregion Public Methods
    }
}
