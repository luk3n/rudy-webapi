using System.Threading.Tasks;
using Rudy.Persistence.Repositories;

namespace Rudy.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private StockContext _context;

        public UnitOfWork(StockContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
        }

        public IClientRepository Clients { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
