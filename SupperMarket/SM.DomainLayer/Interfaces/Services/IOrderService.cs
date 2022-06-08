using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces.Services
{
    public interface IOrderService
    {
        Task<QueryResult<Order>> ListQueryAsync(QueryObjectParams queryObject);
        Task<IEnumerable<Order>> ListAsync();
        Task<Order> SaveAsync(Order order);
        Task<Order> UpdateAsync(int id, Order order);
        Task<Order> Delete(int id);
        Task<Order> GetById(int id);
    }
}
