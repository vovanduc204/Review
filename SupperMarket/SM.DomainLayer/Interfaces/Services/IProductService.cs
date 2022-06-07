using SM.DomainLayer.Comunication.Request;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> SaveAsync(Product product);
        Task<Product> UpdateAsync(int id, Product product);
        Task<Product> Delete(int id);
        Product GetById(int id);
    }
}
