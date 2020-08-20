using System;

namespace Blitz.TransactionScopeWithApi.Dtos
{
    public class NewVisitRequest
    {
        public DateTime VisitOn { get; set; }

        public Guid ClientId { get; set; }
    }
}