using FitnessTrackerAppManagement.Application.Common.Results;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<AuthRegisterResult>
    {
        #region Properties

        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        #endregion Properties
    }
}
