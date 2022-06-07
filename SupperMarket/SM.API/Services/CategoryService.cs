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

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task<Category> SaveAsync(string name)
        {
            var _category = new Category(name);
            _unitOfWork.CategoryRepository.AddSync(_category);
            await _unitOfWork.CompleteAsync();
            return _category;
        }
    }
}
