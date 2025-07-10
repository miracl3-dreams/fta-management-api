using FitnessTrackerAppManagement.Application.Common.Results;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<AuthLoginResult>
    {
        #region Properties

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        #endregion Properties
    }
}
