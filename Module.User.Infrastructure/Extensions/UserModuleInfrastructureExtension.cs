using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.User.Application.Abstractions;
using Module.User.Application.Abstractions.Authentication;
using Module.User.Infrastructure.DbContexts;
using Module.User.Infrastructure.Repositories;
using Module.User.Infrastructure.Services;

namespace Module.User.Infrastructure.Extensions;

public static class UserModuleInfrastructureExtension
{
    public static IServiceCollection AddUserModuleInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Add-Migration InitialMigration -Context UserDbContext -Project Module.User.Infrastructure
        // Update-Database -Context UserDbContext -Project Module.User.Infrastructure

        serviceCollection.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly("Module.User.Infrastructure");
                    optionsBuilder.EnableRetryOnFailure();
                }));
        serviceCollection.AddScoped<ISessionRepository, SessionRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserAccountRepository, UserAccountRepository>();
        serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();
        serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
        

        return serviceCollection;
    }
}