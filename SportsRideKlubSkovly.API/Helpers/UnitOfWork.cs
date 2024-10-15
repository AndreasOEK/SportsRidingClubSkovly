using System.Data;
using SportsRideKlubSkovly.API.Abstractions;

namespace SportsRideKlubSkovly.API.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        Task IUnitOfWork.BeginTransactionAsync(IsolationLevel isolationLevel)
        {
            return Task.CompletedTask;
        }

        Task IUnitOfWork.CommitTransactionAsync()
        {
            return Task.CompletedTask;
        }

        Task IUnitOfWork.RollBackAsync()
        {
            return Task.CompletedTask;
        }
    }
}
