using MediatR;
using FitnessTrackerAppManagement.Application.Common.Interfaces;
using FitnessTrackerAppManagement.Application.Common.Results;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Commands
{
    public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, AuthLoginResult>
    {
        #region Public Methods

        public async Task<AuthLoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await authService.LoginAsync(request.Email, request.Password);
        }

        #endregion Public Methods
    }
}
