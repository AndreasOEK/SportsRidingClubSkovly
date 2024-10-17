using System.ComponentModel.DataAnnotations;

namespace Module.User.Domain.Entity;

public class UserAccount
{
    public Guid Id { get; protected set; }
    
    [MaxLength(100)]
    public string? Username { get; protected set; }
    
    [MaxLength(100)]
    public string? PasswordHash { get; protected set; }

    public User User { get; protected set; }

    protected UserAccount()
    {
        
    }
    
    private UserAccount(string username, string passwordHash, User user)
    {
        Username = username;
        PasswordHash = passwordHash;
        User = user;
    }

    public static UserAccount Create(string username, string password, User user)
        => new UserAccount(username, password, user);
}