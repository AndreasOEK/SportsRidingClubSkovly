using Module.User.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.User.Domain.Entity;

public class Session
{
    public Guid Id { get; protected set; }
    public byte[] RowVersion { get; protected set; }
    public DateTime StartTime { get; protected set; }
    public TimeSpan Duration { get; protected set; }
    public Trainer AssignedTrainer { get; protected set; }
    public int MaxNumberOfParticipants { get; protected set; }
    public SkillLevel DifficultyLevel { get; protected set; }
    public SessionType Type { get; protected set; }
    private List<Booking> _bookings { get; set; } = [];
    public IEnumerable<Booking> Bookings { get { return _bookings; } private set { _bookings = value.ToList(); } }

    protected Session() { }

    private Session(DateTime startTime, TimeSpan duration, Trainer assignedTrainer, int maxNumberOfParticipants, SkillLevel difficultyLevel, SessionType type)
    {
        StartTime = startTime;
        Duration = duration;
        AssignedTrainer = assignedTrainer;
        MaxNumberOfParticipants = maxNumberOfParticipants;
        DifficultyLevel = difficultyLevel;
        Type = type;

        AssureStartTimeInFuture(StartTime, DateTime.Now);
    }

    public static Session Create(DateTime startTime, TimeSpan duration, Trainer assignedTrainer, 
        int availableSlots, SkillLevel difficultyLevel, SessionType type)
        => new Session(startTime, duration, assignedTrainer, availableSlots, difficultyLevel, type);
    
    public void Update(DateTime startTime, TimeSpan duration, Trainer assignedTrainer,
        int maxNumberOfParticipants, SkillLevel difficultyLevel)
    {
        StartTime = startTime;
        Duration = duration;
        AssignedTrainer = assignedTrainer;
        DifficultyLevel = difficultyLevel;

        AssureStartTimeInFuture(StartTime, DateTime.Now);
        AssureMaxParticipantsEqualToOrBiggerThanBookedSlots(maxNumberOfParticipants, _bookings.Count);

        MaxNumberOfParticipants = maxNumberOfParticipants;
    }
    
    public void AddBooking(User user)
    {
        var booking = Booking.Create(user, this, Bookings);

        AssureSlotsToBook(_bookings.Count, MaxNumberOfParticipants);

        _bookings.Add(booking);
    }
    
    public void RemoveBooking(Booking booking)
    {
        AssureSessionIsNotStartedOrDone(StartTime, DateTime.Now);
        
        _bookings.Remove(booking);
    }

    #region Session Domain Logic
    protected void AssureStartTimeInFuture(DateTime startTime, DateTime now)
    {
        if (startTime <= now) 
            throw new ArgumentException("Start Date and Time must be in the future");
    }
    protected void AssureSlotsToBook(int bookingsCount, int maxNumberOfParticipants)
    {
        if (bookingsCount >= maxNumberOfParticipants)
            throw new ArgumentException("All slots has already been booked!");
    }
    protected void AssureMaxParticipantsEqualToOrBiggerThanBookedSlots(int maxParticipants, int bookingsCount)
    {
        if (maxParticipants < bookingsCount)
            throw new ArgumentException("Max Number Of Participants can't be lower than the number of already booked slots!");
    }
    protected void AssureSessionIsNotStartedOrDone(DateTime startDate, DateTime nowDate)
    {
        if (!(startDate > nowDate)) 
            throw new ArgumentException("Session has to be in the future to remove a booking!");
    }
    #endregion


}
