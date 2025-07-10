namespace FitnessTrackerAppManagement.Application.Common.DTOs.Requests
{
    public class FoodUpdateRequest
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }

        #endregion Properties
    }
}
