using FitnessTrackerAppManagement.Application.Common.Results;

namespace FitnessTrackerAppManagement.Application.Common.Interfaces
{
    public interface IAuthService
    {
        #region Private Methods

        Task<AuthLoginResult> LoginAsync(string email, string password);

        Task<AuthRegisterResult> RegisterAsync(string fullName, int age, string email, string password);

        Task<AuthLoginResult> RefreshTokenAsync(string refreshToken);

        Task<bool> RevokeTokenAsync(string refreshToken);

        #endregion Private Methods
    }
}