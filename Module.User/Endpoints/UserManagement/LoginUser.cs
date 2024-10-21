using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Command;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Endpoints.UserManagement;

public class LoginUser : IEndpoint
{
    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapPost("User/Login", async ([FromBody] LoginUserRequest request, [FromServices] IMediator mediator) =>
        {
            var token = await mediator.Send(new LoginUserCommand(request));
            return Results.Ok(new { Token = token });
        }).WithTags("UserManagement");
    }
}
