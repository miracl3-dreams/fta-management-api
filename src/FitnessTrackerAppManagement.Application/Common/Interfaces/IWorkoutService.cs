using FitnessTrackerAppManagement.Application.Common.DTOs.Requests;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;

namespace FitnessTrackerAppManagement.Application.Common.Interfaces
{
    public interface IWorkoutService
    {
        #region Private Methods

        Task<WorkoutDto> CreateWorkoutAsync(WorkoutCreateRequest request);
        Task<List<WorkoutDto>> GetAllWorkoutsAsync();
        Task<WorkoutDto?> GetWorkoutByIdAsync(int id);
        Task<bool> UpdateWorkoutAsync(int id, WorkoutUpdateRequest request);
        Task<bool> DeleteWorkoutAsync(int id);


        #endregion Private Methods
    }
}
