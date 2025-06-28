using Microsoft.AspNetCore.Mvc;
using fta_management_api.Models;
using fta_management_api.Dtos;
using fta_management_api.Data;
using fta_management_api.Services;
using Microsoft.EntityFrameworkCore;

namespace fta_management_api.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly AuthService _authService;

    public AuthController(ApplicationDbContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Email already registered.");

        _authService.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !_authService.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid credentials.");

        var token = _authService.CreateToken(user);
        return Ok(new { token });
    }
}
