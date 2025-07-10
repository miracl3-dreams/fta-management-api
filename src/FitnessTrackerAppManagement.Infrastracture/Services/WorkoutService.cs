using FitnessTrackerAppManagement.Application.Common.DTOs.Requests;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Common.Interfaces;
using FitnessTrackerAppManagement.Domain.Entities;
using FitnessTrackerAppManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Infrastructure.Services
{
    public class WorkoutService : IWorkoutService
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Constructor

        public WorkoutService(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutCreateRequest request)
        {
            var workout = new Workout
            {
                Name = request.Name,
                Description = request.Description,
                DurationInMinutes = request.DurationInMinutes,
                CaloriesBurned = request.CaloriesBurned,
                IntensityLevel = request.IntensityLevel,
                Status = request.Status ?? "Planned",
                UserId = request.UserId,
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync(CancellationToken.None);

            return new WorkoutDto
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                DurationInMinutes = workout.DurationInMinutes,
                CaloriesBurned = workout.CaloriesBurned,
                IntensityLevel = workout.IntensityLevel,
                Status = workout.Status,
                UserId = workout.UserId
            };
        }

        public async Task<List<WorkoutDto>> GetAllWorkoutsAsync()
        {
            return await _context.Workouts
                .Select(w => new WorkoutDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    DurationInMinutes = w.DurationInMinutes,
                    CaloriesBurned = w.CaloriesBurned,
                    IntensityLevel = w.IntensityLevel,
                    Status = w.Status,
                    UserId = w.UserId
                }).ToListAsync();
        }

        public async Task<WorkoutDto?> GetWorkoutByIdAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return null;

            return new WorkoutDto
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                DurationInMinutes = workout.DurationInMinutes,
                CaloriesBurned = workout.CaloriesBurned,
                IntensityLevel = workout.IntensityLevel,
                Status = workout.Status,
                UserId = workout.UserId
            };
        }

        public async Task<bool> UpdateWorkoutAsync(int id, WorkoutUpdateRequest request)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return false;

            workout.Name = request.Name;
            workout.Description = request.Description;
            workout.DurationInMinutes = request.DurationInMinutes;
            workout.CaloriesBurned = request.CaloriesBurned;
            workout.IntensityLevel = request.IntensityLevel;
            workout.Status = request.Status;

            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        #endregion Public Methods
    }
}
