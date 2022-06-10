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
        Task<IEnumerable<Product>> ListProductsAsync();
        Product SaveProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
    }
}
