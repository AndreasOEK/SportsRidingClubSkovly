namespace Module.User.Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    public string Hash(string password);
    bool Verify(string requestPassword, string? accountPassword);
}