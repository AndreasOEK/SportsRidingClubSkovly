using SportsRideKlubSkovly.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
