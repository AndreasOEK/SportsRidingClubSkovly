using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Command;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Endpoints;

public class DeleteUser : IEndpoint
{
    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapDelete("User/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        {
            var request = new DeleteUserRequest(id);
            return await mediator.Send(new DeleteUserCommand(request));
        }).WithTags("UserManagement");
    }
}