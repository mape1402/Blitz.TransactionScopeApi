using System;
using System.Web.Http;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;
using Blitz.TransactionScopeWithApi.Business;
using Blitz.TransactionScopeWithApi.Pipelines;

namespace Blitz.TransactionScopeWithApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IPipelineBehavior _pipelineBehavior;
        private readonly IClientProcessor _clientProcessor;

        public ClientController(IPipelineBehavior pipelineBehavior, IClientProcessor clientProcessor)
        {
            _pipelineBehavior = pipelineBehavior ?? throw new ArgumentNullException(nameof(pipelineBehavior));
            _clientProcessor = clientProcessor ?? throw new ArgumentNullException(nameof(clientProcessor));
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] NewClientRequest request) => await _pipelineBehavior.Handle(request, _clientProcessor.Create);
    }
}
