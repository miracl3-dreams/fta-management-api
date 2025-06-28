using Microsoft.AspNetCore.Mvc;
using fta_management_api.Services;

namespace fta_management_api.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class CalorieController : ControllerBase
{
    private readonly CalorieService _calorieService;

    public CalorieController(CalorieService calorieService)
    {
        _calorieService = calorieService;
    }

    [HttpGet("calculate")]
    public IActionResult Calculate(double weightKg, double heightCm, int age, string gender, string activity)
    {
        var bmr = _calorieService.CalculateBMR(weightKg, heightCm, age, gender);
        var tdee = _calorieService.CalculateTDEE(bmr, activity);
        return Ok(new { bmr, tdee });
    }
}
