using System;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Models;
using Blitz.TransactionScopeWithApi.Persistence;
using Blitz.TransactionScopeWithApi.Repositories.Shared;

namespace Blitz.TransactionScopeWithApi.Repositories.Implementation
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Visit visit)
        {
            _context.Visits.Add(visit);

            await _context.SaveChangesAsync();
        }
    }
}