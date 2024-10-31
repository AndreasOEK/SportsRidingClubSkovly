namespace Module.User.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(Domain.Entity.User user, string role);
}