using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserAccount.Command;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Endpoints.UserAccount;

public class AuthenticateUser : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("Login", async ([FromBody] AuthenticateUserRequest request, [FromServices] IMediator mediator) =>
        await mediator.Send(new AuthenticateUserCommand(request)));
    }
}