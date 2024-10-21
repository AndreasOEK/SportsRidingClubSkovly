using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Command;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Endpoints.UserManagement;

public class CreateUser : IEndpoint
{

    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapPost("User", async ([FromBody] CreateUserRequest request, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(new CreateUserCommand(request));
        }).WithTags("UserManagement");
    }
}
