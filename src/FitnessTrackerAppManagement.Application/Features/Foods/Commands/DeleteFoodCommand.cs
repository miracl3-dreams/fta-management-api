using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Commands
{
    public class DeleteFoodCommand : IRequest<bool>
    {
        #region Properties
        
        public string Name { get; set; }

        #endregion Properties

    }
}
