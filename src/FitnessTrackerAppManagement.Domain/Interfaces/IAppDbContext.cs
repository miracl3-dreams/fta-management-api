using FitnessTrackerAppManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerAppManagement.Domain.Interfaces
{
    public interface IAppDbContext
    {
        #region Properties

        DbSet<User> Users { get; }
        DbSet<UserRole> UserRoles { get; }
        DbSet<Role> Roles { get; }
        DbSet<Calorie> Calories { get; }
        DbSet<Food> Foods { get; }
        DbSet<Workout> Workouts { get; }

        #endregion Properties

        #region Public Methods

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion Public Methods
    }
}
