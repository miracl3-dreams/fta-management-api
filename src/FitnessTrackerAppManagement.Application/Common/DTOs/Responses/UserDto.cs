namespace FitnessTrackerAppManagement.Application.Common.DTOs.Responses
{
    public class UserDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();

        #endregion Properties
    }
}
