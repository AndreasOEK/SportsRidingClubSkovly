using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserSession.Command;
using Module.User.Application.Features.UserSession.Command.Dto;

namespace Module.User.Endpoints.Session;

public class DeleteBooking : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapDelete("/Session/Booking", async ([FromBody]DeleteBookingRequest deleteBookingRequest, [FromServices] IMediator mediator) =>
            await mediator.Send(new DeleteBookingCommand(deleteBookingRequest))
            ).WithTags("Session/Booking");
    }
}