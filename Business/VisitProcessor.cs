using System;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;
using Blitz.TransactionScopeWithApi.Models;
using Blitz.TransactionScopeWithApi.Repositories.Shared;

namespace Blitz.TransactionScopeWithApi.Business
{
    public class VisitProcessor : IVisitProcessor
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IClientRepository _clientRepository;

        public VisitProcessor(IVisitRepository visitRepository, IClientRepository clientRepository)
        {
            _visitRepository = visitRepository ?? throw new ArgumentNullException(nameof(visitRepository));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task RegisterVisit(NewVisitRequest request)
        {
            await _visitRepository.Create(new Visit { Id = Guid.NewGuid(), VisitOn = request.VisitOn });
            //throw new Exception("Die bitch!!");
            await _clientRepository.AddCounter(request.ClientId);
        }
    }
}