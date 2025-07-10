using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Common.DTOs.Requests;

namespace FitnessTrackerAppManagement.Application.Common.Interfaces
{
    public interface IFoodService
    {
        #region Private Methods

        Task<FoodDto> CreateFoodAsync(FoodCreateRequest request);
        Task<List<FoodDto>> GetAllFoodsAsync();
        Task<FoodDto?> GetFoodByIdAsync(int id);
        Task<bool> UpdateFoodAsync(int id, FoodUpdateRequest request);
        Task<bool> DeleteFoodAsync(int id);

        #endregion Private Methods
    }
}
