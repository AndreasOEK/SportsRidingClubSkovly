namespace Module.User.Domain.Entity;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<Booking> Bookings { get; set; }

    protected User() { }

    private User(string firstName, string lastName, string phone, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string phone, string email, string password) =>
        new User(firstName, lastName, phone, email, password);

    public void Update(string firstName, string lastName, string phone, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Password = password;
    }
}
