using System;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;

namespace Blitz.TransactionScopeWithApi.Business
{
    public interface IClientProcessor
    {
        Task<Guid> Create(NewClientRequest request);
    }
}
