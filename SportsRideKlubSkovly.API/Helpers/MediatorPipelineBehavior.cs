using MediatR;
using Module.Shared.Abstractions;
using SportsRideKlubSkovly.API.Abstractions;

namespace SportsRideKlubSkovly.API.Helpers
{
    public class MediatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Type commandMarkerInterface = typeof(ITransactionalCommand);

        public MediatorPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var isTransactionalCommand = commandMarkerInterface.IsAssignableFrom(typeof(TRequest));

            try
            {
                if (isTransactionalCommand)
                    await _unitOfWork.BeginTransactionAsync();

                var response = await next();

                if (isTransactionalCommand)
                    await _unitOfWork.CommitTransactionAsync();

                return response;
            }
            catch (Exception)
            {
                if (isTransactionalCommand)
                    await _unitOfWork.RollBackAsync();

                throw;
            }
        }
    }
}
