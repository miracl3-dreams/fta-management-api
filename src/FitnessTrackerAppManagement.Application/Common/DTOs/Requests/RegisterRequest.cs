namespace FitnessTrackerAppManagement.Application.Common.DTOs.Requests
{
    public class RegisterRequest
    {
        #region Properties
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        #endregion Properties
    }
}
