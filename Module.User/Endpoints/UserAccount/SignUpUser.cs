using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserAccount.Command;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Endpoints.UserAccount;

public class SignUpUser : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/signup",
            ([FromBody] SignUpUserRequest request, [FromServices] IMediator mediator) =>
                mediator.Send(new SignUpUserCommand(request)));
    }
}