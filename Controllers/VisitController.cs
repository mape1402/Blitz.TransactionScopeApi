using System;
using System.Web.Http;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Dtos;
using Blitz.TransactionScopeWithApi.Business;
using Blitz.TransactionScopeWithApi.Pipelines;

namespace Blitz.TransactionScopeWithApi.Controllers
{
    public class VisitController : ApiController
    {
        private readonly IPipelineBehavior _pipelineBehavior;
        private readonly IVisitProcessor _visitProcessor;

        public VisitController(IPipelineBehavior pipelineBehavior, IVisitProcessor visitProcessor)
        {
            _pipelineBehavior = pipelineBehavior ?? throw new ArgumentNullException(nameof(pipelineBehavior));
            _visitProcessor = visitProcessor ?? throw new ArgumentNullException(nameof(visitProcessor));
        }

        [HttpPost]
        public async Task Post([FromBody] NewVisitRequest request) => await _pipelineBehavior.Handle(request, _visitProcessor.RegisterVisit);
    }
}
