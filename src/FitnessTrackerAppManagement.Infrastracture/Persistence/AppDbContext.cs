using Microsoft.EntityFrameworkCore;
using FitnessTrackerAppManagement.Domain.Entities;
using FitnessTrackerAppManagement.Domain.Interfaces;

namespace FitnessTrackerAppManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        #region Public Constructors

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Properties

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Calorie> Calories => Set<Calorie>();
        public DbSet<Food> Foods => Set<Food>();
        public DbSet<Workout> Workouts => Set<Workout>();

        #endregion Properties

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.FullName).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Age).IsRequired();

                entity.HasMany(u => u.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(u => u.Calories)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(u => u.Workouts)
                    .WithOne(w => w.User)
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Role configuration
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.HasIndex(r => r.Name).IsUnique();
            });

            // UserRole configuration (Many-to-Many)
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Calorie configuration
            modelBuilder.Entity<Calorie>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.CaloriesConsumed).IsRequired();
                entity.Property(c => c.CaloriesBurned).IsRequired();
                entity.Property(c => c.Description).HasMaxLength(500);

                entity.HasOne(c => c.User)
                    .WithMany(u => u.Calories)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(c => c.Food)
                    .WithMany(f => f.CaloriesConsumed)
                    .HasForeignKey(c => c.FoodId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(c => c.Workout)
                    .WithMany(w => w.Calories)
                    .HasForeignKey(c => c.WorkoutId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Food configuration
            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Name).IsRequired();
                entity.Property(f => f.Calories).IsRequired();
                entity.Property(f => f.Protein).IsRequired();
                entity.Property(f => f.Carbohydrates).IsRequired();
                entity.Property(f => f.Fats).IsRequired();
                entity.Property(f => f.CreatedAt).IsRequired();
            });

            // Workout configuration
            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.Name).IsRequired();
                entity.Property(w => w.Description).HasMaxLength(500);
                entity.Property(w => w.DurationInMinutes).IsRequired();
                entity.Property(w => w.CaloriesBurned).IsRequired();
                entity.Property(w => w.IntensityLevel).IsRequired();
                entity.Property(w => w.ScheduledAt).IsRequired();
                entity.Property(w => w.Status).IsRequired();

                entity.HasOne(w => w.User)
                    .WithMany(u => u.Workouts)
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            base.OnModelCreating(modelBuilder);
        }

        #endregion Protected Methods
    }
}
