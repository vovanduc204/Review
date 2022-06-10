using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Category SaveCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int id, Category category);
        Task<Category> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
    }
}
