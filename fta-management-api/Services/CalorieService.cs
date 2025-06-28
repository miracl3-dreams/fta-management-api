namespace fta_management_api.Services;

public class CalorieService
{
    public double CalculateBMR(double weightKg, double heightCm, int age, string gender)
    {
        return gender.ToLower() == "male"
            ? 10 * weightKg + 6.25 * heightCm - 5 * age + 5
            : 10 * weightKg + 6.25 * heightCm - 5 * age - 161;
    }

    public double CalculateTDEE(double bmr, string activityLevel)
    {
        return activityLevel.ToLower() switch
        {
            "sedentary" => bmr * 1.2,
            "light" => bmr * 1.375,
            "moderate" => bmr * 1.55,
            "active" => bmr * 1.725,
            "very active" => bmr * 1.9,
            _ => bmr * 1.2
        };
    }
}
