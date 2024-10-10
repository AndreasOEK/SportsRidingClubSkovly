using MediatR;
using Module.Shared.Abstractions;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.TrainerSession.Command.Dto;
using Module.User.Domain.Entity;

namespace Module.User.Application.Features.TrainerSession.Command;

public record CreateSessionCommand (
    CreateSessionRequest createSessionRequest) : IRequest, ITransactionalCommand;


internal class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand>
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IUserRepository _userRepository;

    public CreateSessionCommandHandler(ISessionRepository sessionRepository, IUserRepository userRepository)
    {
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        // Load
        var trainer = await _userRepository.GetTrainerByIdAsync(request.createSessionRequest.AssignedTrainerId);

        // Do
        var session = Session.Create(
            request.createSessionRequest.StartTime,
            request.createSessionRequest.EndTime, 
            trainer, 
            request.createSessionRequest.MaxNumberOfParticipants, 
            request.createSessionRequest.DifficultyLevel, 
            request.createSessionRequest.Type);

        // Save
        await _sessionRepository.AddSessionAsync(session);  
    }
}