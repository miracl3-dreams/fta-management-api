using FitnessTrackerAppManagement.Domain.Interfaces;
using MediatR;

namespace FitnessTrackerAppManagement.Application.Features.Foods.Commands
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, bool>
    {
        #region Fields

        private readonly IAppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public DeleteFoodCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _context.Foods.FindAsync(request.Name);
            if (food == null)
                return false;

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        #endregion Public Methods
    }
}
