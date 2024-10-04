namespace Module.User.Domain.Entity;

public class Trainer
{
    public Guid Id { get; protected set; }

    public User User { get; protected set; }

    public IEnumerable<DerivedEntity.Session> AssignedSessions { get; protected set; }
    
    private Trainer(User user)
    {
        User = user;
    }

    public static Trainer Create(User user) =>
        new Trainer(user);

    public void Update(User user)
    {
        User = user;
    }
}