using Microsoft.EntityFrameworkCore;
using fta_management_api.Models;

namespace fta_management_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<FoodEntry> FoodEntries { get; set; }

    }
}
