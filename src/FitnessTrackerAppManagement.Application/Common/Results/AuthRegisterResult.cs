using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;

namespace FitnessTrackerAppManagement.Application.Common.Results
{
    public class AuthRegisterResult
    {
        #region Properties 

        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new();
        public UserDto? User { get; set; }

        #endregion Properties
    }
}
