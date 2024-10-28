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

    public SignUpUserCommandHandler(IUserAccountRepository userAccountRepository, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userAccountRepository = userAccountRepository;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
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
        
        var account = await _userAccountRepository.GetAccountByUsername(userAccountRequest.Username);

        if (account is null)
            throw new Exception("Account was not found");

        var verified = _passwordHasher.Verify(userAccountRequest.Password, account.PasswordHash);

        if (!verified)
            throw new Exception("Password is incorrect");
        
        return new UserAccountResponse(
            account.User.Id,
            account.User.FirstName + " " + account.User.LastName,
            account.User.Email,
            "User");

    }
}