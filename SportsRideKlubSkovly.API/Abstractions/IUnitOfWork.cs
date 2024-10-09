using System.Data;

namespace SportsRideKlubSkovly.API.Abstractions
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        Task CommitTransactionAsync();
        Task RollBackAsync();
    }
}
