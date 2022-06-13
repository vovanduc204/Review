using Microsoft.EntityFrameworkCore;
using SM.DomainLayer.Core.Extensions;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.InfractureLayer.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> FindAll()
        {
            return _context.Products.ToList().AsQueryable();
        }

        public Task<PaginatedList<Product>> GetListPage(PagingParameter pagingParameters)
        {
            return Task.FromResult(PaginatedList<Product>.GetPagedList(FindAll().OrderBy(s=>s.Id),pagingParameters.PageNumber,pagingParameters.PageSize));
        }

        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    return await _context.Products
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(p => p.CategoryId == id);
        //}

        //public async Task<IReadOnlyList<Product>> GetProductsAsync()
        //{
        //    return await _context.Products
        //        .Include(p => p.Category)
        //        .ToListAsync();
        //}
    }
}
