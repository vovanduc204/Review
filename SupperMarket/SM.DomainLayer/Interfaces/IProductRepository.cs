using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Product GetById(int idProduct)
        {
            var query = GetAll().FirstOrDefault(b => b.Id == idProduct);
            return query;
        }
    }
}
