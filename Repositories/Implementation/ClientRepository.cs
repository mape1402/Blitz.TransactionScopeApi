using System;
using System.Data.Entity;
using System.Threading.Tasks;

using Blitz.TransactionScopeWithApi.Models;
using Blitz.TransactionScopeWithApi.Persistence;
using Blitz.TransactionScopeWithApi.Repositories.Shared;

namespace Blitz.TransactionScopeWithApi.Repositories.Implementation
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCounter(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            client.Counter += 1;

            await _context.SaveChangesAsync();
        }

        public async Task Create(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
    }
}