using MediatR;
using Module.Shared.EventArgs;

namespace Module.User.Application.Features.TrainerCreateSession;

public class CreateSessionCommand : IRequest<Task>
{
    public Guid TrainerId { get; set; }
    public static event EventHandler<SessionCreatedEventArgs> SessionCreated;

    public CreateSessionCommand(Guid trainerId)
    {
        TrainerId = trainerId;
    }

    public virtual void OnSessionCreated(Guid trainerId)
    {
        SessionCreated.Invoke(this, new SessionCreatedEventArgs(trainerId));
    }
}

internal class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Task>
{
    public CreateSessionCommandHandler(CreateSessionCommand command, IMediator mediator)
    {
        mediator.Send(command);
    }
    
    public async Task<Task> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        
        
        request.OnSessionCreated(Guid.NewGuid());

        return Task.CompletedTask;
    }
}