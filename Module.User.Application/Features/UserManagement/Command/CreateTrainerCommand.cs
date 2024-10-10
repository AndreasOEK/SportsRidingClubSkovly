using MediatR;
using Module.Shared.Abstractions;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;
using Module.User.Application.Features.UserManagement.Query.Dto;
using Module.User.Domain.Entity;

namespace Module.User.Application.Features.UserManagement.Command;

public record CreateTrainerCommand(CreateTrainerRequest Request) : IRequest<Task>, ITransactionalCommand;

public class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public CreateTrainerCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Task> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainerRequest = request.Request;
        
        // Load
        var user = await _userRepository.GetUserByIdAsync(trainerRequest.UserId);
        
        // Create
        var trainer = Trainer.Create(user);
        
        //Do & Save
        await _userRepository.CreateTrainerAsync(trainer);

        return Task.CompletedTask;
    }
}