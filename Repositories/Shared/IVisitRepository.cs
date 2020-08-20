using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Models;

namespace Blitz.TransactionScopeWithApi.Repositories.Shared
{
    public interface IVisitRepository
    {
        Task Create(Visit visit);
    }
}
