using Book.DataAccess.Data;
using Book.DataAccess.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _dbcontext;

        public OrderDetailRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Update(OrderDetail obj)
        {
            _dbcontext.OrderDetail.Update(obj);
        }
    }
}
