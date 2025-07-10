using System.Security.Claims;
using FitnessTrackerAppManagement.Domain.Entities;

namespace FitnessTrackerAppManagement.Application.Common.Interfaces
{
    public interface ITokenService
    {
        #region Public Methods

        string GenerateAccessToken(User user, IEnumerable<string> roles);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        #endregion Public Methods
    }
}
