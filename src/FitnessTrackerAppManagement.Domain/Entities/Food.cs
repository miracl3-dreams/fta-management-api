namespace FitnessTrackerAppManagement.Domain.Entities
{
    public class Food
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        #endregion Properties   

        #region Navigation Properties
        public ICollection<Calorie> CaloriesConsumed { get; set; } = new List<Calorie>();

        #endregion Navigation Properties
    }
}
