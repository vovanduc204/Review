using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Order Get(int idOrder)
        {
            var query = GetAll().FirstOrDefault(b => b.Id == idOrder);
            return query;
        }
    }
}
