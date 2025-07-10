namespace FitnessTrackerAppManagement.Application.Common.DTOs.Requests
{
    public class FoodCreateRequest
    {
        #region Properties

        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }

        #endregion Properties
    }
}
