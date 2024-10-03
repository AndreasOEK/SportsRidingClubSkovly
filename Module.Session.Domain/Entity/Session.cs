using Module.Session.Domain.Enums;

namespace Module.Session.Domain.Entity;

public class Session
{
    public DateTime StartTime { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public Trainer AssignedTrainer { get; protected set; }
    public int AvailableSlots { get; protected set; }
    public SkillLevel DifficultyLevel { get; protected set; }
    private List<Booking> _bookings { get; set; }
    public IEnumerable<Booking> Bookings { get { return _bookings; } private set { _bookings = value.ToList(); } }

    protected Session() { }

    private Session(DateTime startTime, DateTime endTime, Trainer assignedTrainer, int availableSlots, SkillLevel difficultyLevel)
    {
        StartTime = startTime;
        EndTime = endTime;
        AssignedTrainer = assignedTrainer;
        AvailableSlots = availableSlots;
        DifficultyLevel = difficultyLevel;
    }

    public static Session Create(DateTime startTime, DateTime endTime, Trainer assignedTrainer, int availableSlots, SkillLevel difficultyLevel)
    {
        return new Session(startTime, endTime, assignedTrainer, availableSlots, difficultyLevel);
    }

    public void AddBooking(Booking booking)
    {

    }
}
