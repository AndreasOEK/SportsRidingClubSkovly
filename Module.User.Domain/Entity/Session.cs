using Module.User.Domain.Enums;

namespace Module.User.Domain.Entity;

public class Session
{
    public Guid Id { get; protected set; }
    public DateTime StartTime { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public Trainer AssignedTrainer { get; protected set; }
    public int MaxNumberOfParticipants { get; protected set; }
    public SkillLevel DifficultyLevel { get; protected set; }
    public SessionType Type { get; protected set; }
    private List<Booking> _bookings { get; set; }
    public IEnumerable<Booking> Bookings { get { return _bookings; } private set { _bookings = value.ToList(); } }

    protected Session() { }

    private Session(DateTime startTime, DateTime endTime, Trainer assignedTrainer, int maxNumberOfParticipants, SkillLevel difficultyLevel, SessionType type)
    {
        StartTime = startTime;
        EndTime = endTime;
        AssignedTrainer = assignedTrainer;
        MaxNumberOfParticipants = maxNumberOfParticipants;
        DifficultyLevel = difficultyLevel;
        Type = type;

        AssureStartTimeInFuture(StartTime, DateTime.Now);
        AssureEndTimeAfterStartTime(StartTime, EndTime);
    }

    public static Session Create(DateTime startTime, DateTime endTime, Trainer assignedTrainer, 
        int availableSlots, SkillLevel difficultyLevel, SessionType type)
        => new Session(startTime, endTime, assignedTrainer, availableSlots, difficultyLevel, type);
    
    public void Update(DateTime startTime, DateTime endTime, Trainer assignedTrainer,
        int maxNumberOfParticipants, SkillLevel difficultyLevel)
    {
        StartTime = startTime;
        EndTime = endTime;
        AssignedTrainer = assignedTrainer;
        DifficultyLevel = difficultyLevel;

        AssureStartTimeInFuture(StartTime, DateTime.Now);
        AssureEndTimeAfterStartTime(StartTime, EndTime);
        AssureMaxParticipantsEqualToOrBiggerThanBookedSlots(maxNumberOfParticipants, _bookings.Count);

        MaxNumberOfParticipants = maxNumberOfParticipants;
    }
    
    public void AddBooking(User user)
    {
        var booking = Booking.Create(user, Bookings);

        AssureSlotsToBook(_bookings.Count, MaxNumberOfParticipants);

        _bookings.Add(booking);
    }

    #region Session Domain Logic
    protected void AssureStartTimeInFuture(DateTime startTime, DateTime now)
    {
        if (!(startTime > now)) throw new ArgumentException("Start Date and Time must be in the future");
    }
    protected void AssureEndTimeAfterStartTime(DateTime startTime, DateTime endTime)
    {
        if (!(endTime > startTime)) throw new ArgumentException("End date has to be after Start date");
    }
    protected void AssureSlotsToBook(int bookingsCount, int maxNumberOfParticipants)
    {
        if (!(bookingsCount < maxNumberOfParticipants))
            throw new ArgumentException("All slots has already been booked!");
    }
    protected void AssureMaxParticipantsEqualToOrBiggerThanBookedSlots(int maxParticipants, int bookingsCount)
    {
        if (!(maxParticipants >= bookingsCount))
            throw new ArgumentException("Max Number Of Participants can't be lower than the number of already booked slots!");
    }
    #endregion
}
