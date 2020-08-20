using System;
using System.Threading.Tasks;

namespace Blitz.TransactionScopeWithApi.Pipelines
{
    public interface IPipelineBehavior
    {
        Task<TResponse> Handle<TRequest, TResponse>(TRequest request, Func<TRequest, Task<TResponse>> function);

        Task Handle<TRequest>(TRequest request, Func<TRequest, Task> function);

        Task<TResponse> Handle<TResponse>(Func<Task<TResponse>> function);

        Task Handle(Func<Task> function);
    }
}
