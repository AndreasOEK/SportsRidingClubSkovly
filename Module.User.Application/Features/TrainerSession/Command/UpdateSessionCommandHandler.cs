using MediatR;
using Module.Shared.Abstractions;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.TrainerSession.Command.Dto;

namespace Module.User.Application.Features.TrainerSession.Command
{
    public record UpdateSessionCommand (
        UpdateSessionRequest updateSessionRequest) : IRequest, ITransactionalCommand;
    
    public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;

        public UpdateSessionCommandHandler(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {
            // Load
            var trainer = await _userRepository.GetTrainerByIdAsync(request.updateSessionRequest.AssignedTrainerId);
            var session = await _sessionRepository.GetSessionByIdAsync(request.updateSessionRequest.Id);

            // Do
            session.Update(
                request.updateSessionRequest.StartTime,
                request.updateSessionRequest.EndTime,
                trainer,
                request.updateSessionRequest.MaxNumberOfParticipants,
                request.updateSessionRequest.DifficultyLevel
                );

            // Save
            await _sessionRepository.UpdateSessionAsync(session, request.updateSessionRequest.RowVersion);
        }
    }
}
