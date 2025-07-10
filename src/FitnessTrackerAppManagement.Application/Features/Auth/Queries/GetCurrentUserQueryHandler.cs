using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Queries
{
    public class GetCurrentUserQueryHandler(IUserRepository userRepository,
        IRoleRepository roleRepository
        ) : IRequestHandler<GetCurrentUserQuery, UserDto?>
    {
        #region Public Methods

        public async Task<UserDto?> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return null;

            var roles = await roleRepository.GetUserRolesAsync(user.Id);

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Age = user.Age,
                Email = user.Email,
                Roles = roles.Select(r => r.Name).ToList()
            };
        }

        #endregion Public Methods
    }
}
