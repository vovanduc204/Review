using Microsoft.Extensions.Caching.Memory;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Enums;
using SM.DomainLayer.Interfaces;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Repository<Category>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _unitOfWork.Repository<Category>().ListAllAsync();
        }

        public Category SaveCategoryAsync(Category category)
        {
            _unitOfWork.Repository<Category>().Add(category);
            _unitOfWork.CompleteAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var categoryExisting = await _unitOfWork.Repository<Category>().GetByIdAsync(id);

            var listProducts = await _unitOfWork.Repository<Product>().ListAllAsync();

            int checkExisting = 0;
            foreach (var product in listProducts)
            {
                if (product.CategoryId == categoryExisting.Id) checkExisting++; break;
            }
            if (checkExisting == 0)
                if (categoryExisting != null)
                    _unitOfWork.Repository<Category>().Update(categoryExisting);
                    await _unitOfWork.CompleteAsync();

            return categoryExisting;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var categoryExisting = await _unitOfWork.Repository<Category>().GetByIdAsync(id);
            var listProducts = await _unitOfWork.Repository<Product>().ListAllAsync();

            int checkExisting = 0;
            foreach (var product in listProducts)
            {
                if (product.CategoryId == categoryExisting.Id) checkExisting++; break;
            }
            if (checkExisting == 0)
                if (categoryExisting != null)
                    if (categoryExisting != null)
                _unitOfWork.Repository<Category>().Delete(categoryExisting);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return categoryExisting;
        }
    }
}
