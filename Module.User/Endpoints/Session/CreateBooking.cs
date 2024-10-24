using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserSession.Command;
using Module.User.Application.Features.UserSession.Command.Dto;

namespace Module.User.Endpoints.Session
{
    public class CreateBooking : IEndpoint
    {
        void IEndpoint.MapEndpoint(WebApplication app)
        {
            app.MapPost("/Session/booking", async ([FromBody] CreateBookingRequest createBookingRequest, [FromServices] IMediator mediator) =>
                await mediator.Send(new CreateBookingCommand(createBookingRequest))
            ).WithTags("Session/Booking");
        }
    }
}
