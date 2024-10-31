using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Abstractions.Authentication;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Application.Features.UserAccount.Command;

public record SignUpUserCommand(SignUpUserRequest Request) : IRequest<UserAccountResponse>;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, UserAccountResponse>
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMediator _mediator;

    public SignUpUserCommandHandler(IUserAccountRepository userAccountRepository, IUserRepository userRepository, IPasswordHasher passwordHasher, IMediator mediator)
    {
        _userAccountRepository = userAccountRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mediator = mediator;
    }

    public async Task<UserAccountResponse> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        var userAccountRequest = request.Request;

        var emailAlreadyExists = await _userRepository.DoesUserExist(userAccountRequest.Username);

        if (emailAlreadyExists)
            throw new Exception("Email already exists");
        
        var user = Domain.Entity.User.Create(userAccountRequest.FirstName, userAccountRequest.LastName, userAccountRequest.Phone, userAccountRequest.Email);

        var passwordHash = _passwordHasher.Hash(userAccountRequest.Password);
        
        var userAccount = Domain.Entity.UserAccount.Create(userAccountRequest.Username, passwordHash, user);

        await _userAccountRepository.AddAccount(userAccount);

        return await _mediator.Send(
            new AuthenticateUserCommand(new AuthenticateUserRequest(userAccountRequest.Username,
                userAccountRequest.Password)), cancellationToken);

    }
}