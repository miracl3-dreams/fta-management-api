using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fta_management_api.Models;
using fta_management_api.Data;
using Microsoft.EntityFrameworkCore;

namespace fta_management_api.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WorkoutsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public WorkoutsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddWorkout(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return Ok(workout);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserWorkouts(int userId)
    {
        var workouts = await _context.Workouts
            .Where(w => w.UserId == userId)
            .ToListAsync();

        return Ok(workouts);
    }
}
