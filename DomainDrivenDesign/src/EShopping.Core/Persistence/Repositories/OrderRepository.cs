using EShopping.Core.Domain.Entities;
using EShopping.Core.Domain.Repositories;
using GenericRepositoryEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EShoppingDbContext context) : base(context)
        {

        }

        public EShoppingDbContext EShoppingDbContext
        {
            get { return Context as EShoppingDbContext; }
        }

        public override void Add(Order entity)
        {
            // We can override repository virtual methods in order to customize repository behavior, Template Method Pattern
            // Code here

            base.Add(entity);
        }

    }
}
