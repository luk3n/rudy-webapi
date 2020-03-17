using Rudy.Models;

namespace Rudy.Persistence.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(StockContext context)
            : base(context)
        {
        }

        public StockContext StockContext
        {
            get { return Context as StockContext; }
        }
    }
}
