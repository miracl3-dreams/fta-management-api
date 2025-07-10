namespace FitnessTrackerAppManagement.Application.Common.Results
{
    public class FoodResult
    {
        #region Properties

        public bool Success { get; set; }
        public string? Message { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }

        #endregion Properties
    }
}
