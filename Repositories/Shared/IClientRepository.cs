using System;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Models;

namespace Blitz.TransactionScopeWithApi.Repositories.Shared
{
    public interface IClientRepository
    {
        Task Create(Client client);

        Task AddCounter(Guid id);
    }
}
