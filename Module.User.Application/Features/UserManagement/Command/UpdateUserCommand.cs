using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Application.Features.UserManagement.Command;

public record UpdateUserCommand(UpdateUserRequest Request) : IRequest<Task>;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Task> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var updateRequest = request.Request;
        
        // Load
        var user = await _userRepository.GetUserByIdAsync(updateRequest.Guid);
        
        // Do
        user.Update(updateRequest.FirstName, updateRequest.LastName, updateRequest.Phone, updateRequest.Email);
        
        // Save
        await _userRepository.UpdateUserAsync(user);

        return Task.CompletedTask;
    }
}