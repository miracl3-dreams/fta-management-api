using FitnessTrackerAppManagement.Application.Common.Results;

namespace FitnessTrackerAppManagement.Application.Common.Interfaces
{
    public interface ICalorieService
    {
        #region Private Methods

        Task<CalorieResult> LogCaloriesAsync(Guid userId, int? foodId, int? workoutId, string? description);

        #endregion Private Methods
    }
}
