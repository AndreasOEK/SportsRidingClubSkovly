using MediatR;
using Module.Shared.EventArgs;

namespace Module.User.Application.Features.TrainerCreateSession.Command;

public class CreateSessionCommand : IRequest<Task>
{
    public Guid TrainerId { get; set; }

    public CreateSessionCommand()
    {
    }
}

internal class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Task>
{
    public CreateSessionCommandHandler()
    {
    }

    public async Task<Task> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}