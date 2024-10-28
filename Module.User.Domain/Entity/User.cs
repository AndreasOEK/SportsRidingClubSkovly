namespace Module.User.Domain.Entity;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IEnumerable<Booking> Bookings { get; set; }

    protected User() { }

    private User(string firstName, string lastName, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }
    
    private User(Guid id, string firstName, string lastName, string phone, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }

    public static User Create(string firstName, string lastName, string phone, string email) =>
        new User(firstName, lastName, phone, email);
    
    public static User Create(Guid id, string firstName, string lastName, string phone, string email) =>
        new User(id, firstName, lastName, phone, email);

    public void Update(string firstName, string lastName, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }
}