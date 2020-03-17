using System;
using System.Threading.Tasks;
using Rudy.Persistence.Repositories;

namespace Rudy.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IProductRepository Products { get; }
        Task<int> Complete();
    }
}
