using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserSession.Command.Dto;

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
        var session = await _sessionRepository.GetSessionByIdAsync(request.DeleteBookingRequest.SessionId);
        var booking = await _sessionRepository.GetBookingByIdAsync(request.DeleteBookingRequest.BookingId);
        
        // Do
        session.RemoveBooking(booking);
        
        // Save
        await _sessionRepository.DeleteBookingAsync(booking, request.DeleteBookingRequest.RowVersion);
    }
}