using System.Data.Entity;
using Blitz.TransactionScopeWithApi.Models;

namespace Blitz.TransactionScopeWithApi.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}