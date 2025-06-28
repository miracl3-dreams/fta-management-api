using System.ComponentModel.DataAnnotations.Schema;

namespace fta_management_api.Models;

public class Workout
{
    public int Id { get; set; }
    public string? Type { get; set; } 
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }
    public int CaloriesBurned { get; set; }

    // Foreign Key
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}
