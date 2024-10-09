using Microsoft.Extensions.DependencyInjection;
using Module.User.Application.Features.TrainerSession.Command;

namespace Module.User.Application.Extensions;

public static class UserModuleApplicationExtension
{
    public static IServiceCollection AddUserModuleApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}