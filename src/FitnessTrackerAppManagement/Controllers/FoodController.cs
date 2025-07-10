using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Application.Features.Foods.Commands;
using FitnessTrackerAppManagement.Application.Features.Foods.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerAppManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController(IMediator mediator) : ControllerBase
    {
        #region Public Methods

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateFoodAsync([FromBody] CreateFoodCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<FoodDto>>> GetAllFoodsAsync()
        {
            var query = new GetAllFoodQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<List<FoodDto>>> GetFoodById(int id)
        {
            var query = new GetFoodByIdQuery { Id = id };
            var result = await mediator.Send(query);

            if (result == null)
                return NotFound($"Foods with ID {id} not found");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<bool>> UpdateFood(string Name, [FromBody] UpdateFoodCommand command)
        {
            if (Name != command.Name)
                return BadRequest("Name in URL does not match in request body");

            var result = await mediator.Send(command);

            if (!result)
                return NotFound($"Food with Name {Name} not found");

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteFood(string Name)
        {
            var command = new DeleteFoodCommand { Name = Name };
            var result = await mediator.Send(command);

            if (!result)
                return NotFound($"Food with Name {Name} not found");
            return Ok(result);
        }

        #endregion Public Method
    }
}
