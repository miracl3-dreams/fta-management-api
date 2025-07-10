using FitnessTrackerAppManagement.Application.Common.Results;
using FitnessTrackerAppManagement.Application.Common.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Commands
{
    public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, AuthRegisterResult>
    {
        #region Public Methods

        public async Task<AuthRegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await authService.RegisterAsync(
                request.FullName,
                request.Age,
                request.Email,
                request.Password);
        }

        #endregion Public Methods
    }
}
