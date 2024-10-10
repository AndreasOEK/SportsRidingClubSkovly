using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Application.Features.UserManagement.Command;

public record DeleteTrainerCommand(DeleteTrainerRequest Request) : IRequest<Task>;

public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public DeleteTrainerCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Task> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    {
        var deleteRequest = request.Request;
        
        // Load
        var trainer = await _userRepository.GetTrainerByIdAsync(deleteRequest.Guid);
        
        // Do & Save
        await _userRepository.DeleteTrainerAsync(trainer);

        return Task.CompletedTask;
    }
}