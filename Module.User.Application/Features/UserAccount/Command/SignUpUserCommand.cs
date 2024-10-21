using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Application.Features.UserAccount.Command;

public record SignUpUserCommand(SignUpUserRequest Request) : IRequest<UserAccountResponse>;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, UserAccountResponse>
{
    private readonly IUserAccountRepository _userAccountRepository;

    public SignUpUserCommandHandler(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task<UserAccountResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var signupRequest = request.Request;

        var emailAlreadyExists = await _userAccountRepository.DoesEmailExist(signupRequest.Username);
            

        if (emailAlreadyExists)
            throw new Exception("Email already exists");
        
        var user = Domain.Entity.User.Create(signupRequest.FirstName, signupRequest.LastName, signupRequest.Phone, signupRequest.Email);

        var passwordHash = _passwordHasher.Hash(signupRequest.Password);
        
        var userAccount = Domain.Entity.UserAccount.Create(signupRequest.Username, passwordHash, user);

        await _userAccountRepository.AddAccount(userAccount);
        
        var authenticateRequest = request.Request;
        var account = await _userAccountRepository.GetAccountByUsername(authenticateRequest.Username);

        if (account is null)
            throw new Exception("Account was not found");

        var verified = _passwordHasher.Verify(authenticateRequest.Password, account.PasswordHash);

        if (!verified)
            throw new Exception("Password is incorrect");

        var isTrainer = await _userRepository.IsUserTrainer(account.User.Id);
        
        return new UserAccountResponse(
            account.User.Id,
            account.User.FirstName,
            account.User.LastName,
            account.User.Email,
            isTrainer);

    }
}