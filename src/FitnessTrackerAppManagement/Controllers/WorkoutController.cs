using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Features.Workouts.Commands;
using FitnessTrackerAppManagement.Application.Features.Workouts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerAppManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController(IMediator _mediator) : ControllerBase
    {
        #region Public Methods

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateWorkoutAsync([FromBody] CreateWorkoutCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutAsync()
        {
            var query = new GetAllWorkoutQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<WorkoutDto>> GetWorkoutById(int id)
        {
            var query = new GetWorkoutByIdQuery { Id = id };

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"Workout with ID {id} not found");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<bool>> UpdateWorkout(int id, [FromBody] UpdateWorkoutCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in URL does not match in request body");

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound($"Workout with ID {id} not found");

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteWorkout(string Name)
        {
            var command = new DeleteWorkoutCommand { Name = Name };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"Workout with ID {Name} not found");
            return Ok(result);
        }

        #endregion Public Methods
    }
}
