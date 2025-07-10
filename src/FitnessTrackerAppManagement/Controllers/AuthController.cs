using FitnessTrackerAppManagement.Application.Common.DTOs.Requests;
using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Common.Results;
using FitnessTrackerAppManagement.Application.Features.Auth.Commands;
using FitnessTrackerAppManagement.Application.Features.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTrackerAppManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        #region Public Methods

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthLoginResult>> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<AuthLoginResult>> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand
            {
                FullName = request.FullName,
                Age = request.Age,
                Email = request.Email,
                Password = request.Password
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var query = new GetCurrentUserQuery { UserId = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("admin-only")]
        public ActionResult<string> AdminOnly()
        {
            return Ok("This endpoint is only accessible to admins!");
        }

        #endregion Public Methods
    }
}
