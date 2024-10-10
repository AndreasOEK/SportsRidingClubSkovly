using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Command;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Endpoints;

public class UpdateUser : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPut("User", async ([FromBody]UpdateUserRequest request, [FromServices]IMediator mediator) 
            =>
            {
                await mediator.Send(new UpdateUserCommand(request));
                return Results.Ok();
            })
            .WithTags("UserManagement");
    }
}