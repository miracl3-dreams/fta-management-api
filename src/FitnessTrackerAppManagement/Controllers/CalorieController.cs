using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Features.Calories.Commands;
using FitnessTrackerAppManagement.Application.Features.Calories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerAppManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalorieController(IMediator _mediator) : ControllerBase
    {
        #region Public Methods

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateCalorie([FromBody] CreateCalorieCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<CalorieDto>>> GetAllCalories()
        {
            var query = new GetAllCaloriesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<CalorieDto>> GetCalorieById(int id)
        {
            var query = new GetCalorieByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"Calorie with ID {id} not found");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateCalorie(int id, [FromBody] UpdateCalorieCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in URL does not match ID in request body.");

            var result = await _mediator.Send(command);
            
            if (!result)
                return NotFound($"Calorie with ID {id} not found");

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCalorie(int id)
        {
            var command = new DeleteCalorieCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"Driver with ID {id} not found.");

            return Ok(result);
        }

        #endregion Public Methods
    }
}