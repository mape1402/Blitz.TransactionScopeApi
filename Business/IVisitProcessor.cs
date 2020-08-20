using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;

namespace Blitz.TransactionScopeWithApi.Business
{
    public interface IVisitProcessor
    {
        Task RegisterVisit(NewVisitRequest request);
    }
}
