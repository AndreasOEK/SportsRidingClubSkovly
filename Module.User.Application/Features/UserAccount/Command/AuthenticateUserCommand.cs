using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Abstractions.Authentication;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Application.Features.UserAccount.Command;

public record AuthenticateUserCommand(AuthenticateUserRequest Request) : IRequest<UserAccountResponse>;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserAccountResponse>
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthenticateUserCommandHandler(IUserAccountRepository userAccountRepository, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userAccountRepository = userAccountRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<UserAccountResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var authenticateRequest = request.Request;
        var account = await _userAccountRepository.GetAccountByUsername(authenticateRequest.Username);

        if (account is null)
            throw new Exception("Username or password was incorrect");

        var verified = _passwordHasher.Verify(authenticateRequest.Password, account.PasswordHash);

        if (!verified)  
            throw new Exception("Username or password was incorrect");

        var isTrainer = await _userRepository.IsUserTrainer(account.User.Id);

        return new UserAccountResponse(
            account.User.Id,
            account.User.FirstName + " " + account.User.LastName,
            account.User.Email,
            isTrainer);
    }
}