namespace Module.User.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string Generate(Domain.Entity.User user);
}