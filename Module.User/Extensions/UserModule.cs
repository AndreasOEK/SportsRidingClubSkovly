using Microsoft.Extensions.DependencyInjection;
using Module.User.Application.Extensions;
using Module.User.Infrastructure.Extensions;

namespace Module.User.Extensions
{
    public static class UserModule
    {
        public static IServiceCollection AddUserModule(this IServiceCollection serviceCollection)
        {

            return serviceCollection
                .AddUserModuleApplication()
                .AddUserModuleInfrastructure();
        }
    }
}
