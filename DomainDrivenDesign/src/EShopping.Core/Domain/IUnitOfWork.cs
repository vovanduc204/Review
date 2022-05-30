using EShopping.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShopping.Core.Domain
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }

        Task<int> CompleteAsync();

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
