using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Extensions;

public static class UserModuleInfrastructureExtension
{
    public static IServiceCollection AddUserModuleInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly("Module.User.Infrastructure");
                    optionsBuilder.EnableRetryOnFailure();
                }));

        return serviceCollection;
    }
}