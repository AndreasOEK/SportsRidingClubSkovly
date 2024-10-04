using Module.User.Domain.Enums;

namespace Module.User.Domain.Entity;

public class Session
{
    public DateTime StartTime { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public Trainer AssignedTrainer { get; protected set; }
    public int AvailableSlots { get; protected set; }
    public SkillLevel DifficultyLevel { get; protected set; }
    public SessionType Type { get; protected set; }
    private List<Booking> _bookings { get; set; }
    public IEnumerable<Booking> Bookings { get { return _bookings; } private set { _bookings = value.ToList(); } }

    protected Session() { }

    private Session(DateTime startTime, DateTime endTime, Trainer assignedTrainer, int availableSlots, SkillLevel difficultyLevel, SessionType type)
    {
        StartTime = startTime;
        EndTime = endTime;
        AssignedTrainer = assignedTrainer;
        AvailableSlots = availableSlots;
        DifficultyLevel = difficultyLevel;
        Type = type;

        AssureStartTimeInFuture(StartTime, DateTime.Now);
    }

    public static Session Create(DateTime startTime, DateTime endTime, Trainer assignedTrainer, int availableSlots, SkillLevel difficultyLevel, SessionType type)
    {
        return new Session(startTime, endTime, assignedTrainer, availableSlots, difficultyLevel, type);
    }

    public void AddBooking(User user)
    {
        var booking = Booking.Create(user, Bookings);
        _bookings.Add(booking);
    }

    #region Session Domain Logic
    private void AssureStartTimeInFuture(DateTime startTime, DateTime now)
    {
        if (!(startTime > now)) throw new ArgumentException("Start Date and Time must be in the future");
    }
    #endregion
}
