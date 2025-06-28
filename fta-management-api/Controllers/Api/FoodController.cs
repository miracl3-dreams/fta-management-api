using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fta_management_api.Data;
using fta_management_api.Dtos;
using fta_management_api.Models;

namespace fta_management_api.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FoodController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FoodController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddFood(int userId, [FromBody] FoodEntryDto dto)
    {
        var food = new FoodEntry
        {
            Name = dto.Name,
            Calories = dto.Calories,
            Protein = dto.Protein,
            Carbs = dto.Carbs,
            Fat = dto.Fat,
            Date = DateTime.Now,
            UserId = userId
        };

        _context.FoodEntries.Add(food);
        await _context.SaveChangesAsync();
        return Ok(food);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetFoodLog(int userId)
    {
        var foods = _context.FoodEntries
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.Date)
            .ToList();

        return Ok(foods);
    }
}
