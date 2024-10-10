using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Application.Features.UserManagement.Command;

public record DeleteUserCommand(DeleteUserRequest Request): IRequest<Task>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Task> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var deleteRequest = request.Request;
        
        // Load
        var user = await _userRepository.GetUserByIdAsync(deleteRequest.Guid);
        
        // Do & Save
        await _userRepository.DeleteUserAsync(user);
        
        return Task.CompletedTask;
    }
}