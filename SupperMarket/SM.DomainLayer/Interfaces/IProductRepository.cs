using SM.DomainLayer.Core.Extensions;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces
{
    public interface IProductRepository<T>
    {
        //    Task<Product> GetProductByIdAsync(int id);
        //    Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<PaginatedList<Product>> GetListPage(PagingParameter pagingParameters);
        IQueryable<T> FindAll();
    }
}
