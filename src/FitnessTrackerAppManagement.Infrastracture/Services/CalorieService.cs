using FitnessTrackerAppManagement.Application.Common.Interfaces;
using FitnessTrackerAppManagement.Application.Common.Results;
using FitnessTrackerAppManagement.Domain.Entities;
using FitnessTrackerAppManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Infrastructure.Services
{
    public class CalorieService : ICalorieService
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public CalorieService(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<CalorieResult> LogCaloriesAsync(Guid userId, int? foodId, int? workoutId, string? description)
        {
            var food = foodId.HasValue
                ? await _context.Foods.FirstOrDefaultAsync(f => f.Id == foodId.Value)
                : null;

            var workout = workoutId.HasValue
                ? await _context.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId.Value)
                : null;

            var calorieEntry = new Calorie
            {
                UserId = userId,
                FoodId = food?.Id,
                WorkoutId = workout?.Id,
                CaloriesConsumed = food?.Calories ?? 0,
                CaloriesBurned = workout?.CaloriesBurned ?? 0,
                Description = description
            };

            _context.Calories.Add(calorieEntry);
            await _context.SaveChangesAsync();

            return new CalorieResult
            {
                Success = true,
                Message = "Calorie log recorded successfully.",
                CaloriesConsumed = calorieEntry.CaloriesConsumed,
                CaloriesBurned = calorieEntry.CaloriesBurned
            };
        }

        #endregion Public Methods
    }

}
