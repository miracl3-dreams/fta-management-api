using FitnessTrackerAppManagement.Application.Common.Interfaces;
using FitnessTrackerAppManagement.Domain.Interfaces;
using FitnessTrackerAppManagement.Infrastructure.Data;
using FitnessTrackerAppManagement.Infrastructure.Repositories;
using FitnessTrackerAppManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace FitnessTrackerAppManagement.Infrastructure
{
    public static class DependencyInjection
    {
        #region Public Methods

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            IServiceCollection serviceCollection = services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        #endregion Public Methods
    }
}
