using System;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;
using Blitz.TransactionScopeWithApi.Models;
using Blitz.TransactionScopeWithApi.Repositories.Shared;

namespace Blitz.TransactionScopeWithApi.Business
{
    public class ClientProcessor : IClientProcessor
    {
        private readonly IClientRepository _clientRepository;

        public ClientProcessor(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<Guid> Create(NewClientRequest request)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Counter = default(int)
            };

            await _clientRepository.Create(client);

            return client.Id;
        }
    }
}