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
        app.MapPost("SignUp", async ([FromBody] SignUpUserRequest request, [FromServices] IMediator mediator) => 
            await mediator.Send(new SignUpUserCommand(request)));
    }
}