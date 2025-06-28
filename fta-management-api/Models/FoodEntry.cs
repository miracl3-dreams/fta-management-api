using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fta_management_api.Models;

public class FoodEntry
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public DateTime Date { get; set; }

    // User FK
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}
