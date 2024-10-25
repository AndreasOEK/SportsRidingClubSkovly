using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserSession.Command.Dto;
using Module.User.Domain.Entity;

namespace Module.User.Application.Features.UserSession.Command;

public record DeleteBookingCommand (
    DeleteBookingRequest DeleteBookingRequest) : IRequest;

internal class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
{
    private readonly ISessionRepository _sessionRepository;

    public DeleteBookingCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }
    public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        // Load
        var booking = await _sessionRepository.GetBookingByIdAsync(request.DeleteBookingRequest.BookingId);
        var session = await _sessionRepository.GetSessionByIdAsync(booking.Session.Id);
        
        // Do
        session.RemoveBooking(booking);
        
        // Save
        await _sessionRepository.DeleteBookingAsync(booking);
    }
}