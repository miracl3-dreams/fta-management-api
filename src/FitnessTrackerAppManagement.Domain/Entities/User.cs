using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerAppManagement.Domain.Entities
{
    public class User
    {
        #region Properties

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required, Range(1, 120)]
        public int Age { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Role Mapping 

        [Required]
        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Calorie> Calories { get; set; } 
        public ICollection<Workout> Workouts { get; set; } 

        #endregion Properties
    }
}
