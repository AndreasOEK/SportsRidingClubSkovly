namespace Module.Shared.EventArgs;

public class SessionCreatedEventArgs : System.EventArgs
{
    public Guid TrainerId { get; }

    public SessionCreatedEventArgs(Guid trainerId)
    {
        TrainerId = trainerId;
    }
}