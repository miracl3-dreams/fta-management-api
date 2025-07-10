using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Commands
{
    public class CreateFoodCommand : IRequest<string>
    {
        #region Properties
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}
