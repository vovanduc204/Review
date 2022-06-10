using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>();
        Task<int> CompleteAsync();
        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
