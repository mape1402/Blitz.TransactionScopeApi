using System;
using System.Transactions;
using System.Threading.Tasks;

namespace Blitz.TransactionScopeWithApi.Pipelines
{
    public class TransactionBehavior : IPipelineBehavior
    {
        public async Task<TResponse> Handle<TRequest, TResponse>(TRequest request, Func<TRequest, Task<TResponse>> function)
        {
            using (var transaction = GetTransactionScope(GetTransactionOptions()))
            {
                var response = await function(request);

                transaction.Complete();

                return response;
            }
        }

        public async Task Handle<TRequest>(TRequest request, Func<TRequest, Task> function)
        {
            using (var transaction = GetTransactionScope(GetTransactionOptions()))
            {
                await function(request);

                transaction.Complete();
            }
        }

        public async Task<TResponse> Handle<TResponse>(Func<Task<TResponse>> function)
        {
            using (var transaction = GetTransactionScope(GetTransactionOptions()))
            {
                var response = await function();

                transaction.Complete();

                return response;
            }
        }

        public async Task Handle(Func<Task> function)
        {
            using (var transaction = GetTransactionScope(GetTransactionOptions()))
            {
                await function();

                transaction.Complete();
            }
        }

        private TransactionOptions GetTransactionOptions() => new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TransactionManager.MaximumTimeout
        };

        private TransactionScope GetTransactionScope(TransactionOptions options) => new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
    }
}