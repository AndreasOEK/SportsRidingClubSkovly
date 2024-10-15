using MediatR;
using Module.Shared.Abstractions;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserSession.Command.Dto;

namespace Module.User.Application.Features.UserSession.Command
{
    public record CreateBookingCommand(
        CreateBookingRequest CreateBookingRequest) : IRequest, ITransactionalCommand;
    internal class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;

        public CreateBookingCommandHandler(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }
        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            // Load
            var session = await _sessionRepository.GetSessionByIdAsync(request.CreateBookingRequest.sessionId);
            var user = await _userRepository.GetUserByIdAsync(request.CreateBookingRequest.userId);

            // Do
            session.AddBooking(user);

            // Save
            await _sessionRepository.AddBookingAsync();
        }
    }
}
