using FitnessTrackerAppManagement.Application.Common.DTOs.Responses;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Auth.Queries
{
    public class GetCurrentUserQuery : IRequest<UserDto?>
    {
        #region Properties

        public Guid UserId { get; set; }

        #endregion Properties
    }
}
