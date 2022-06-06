using Microsoft.Extensions.Caching.Memory;
using SM.DomainLayer.Comunication.Request;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public Task<IEnumerable<Product>> ListAsync()
        {
            return _productRepository.GetAllAsync();
        }

        public async Task<Product> SaveAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return null;
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            //await _productRepository.Update(product);

            return null;
        }


        public Task<Product> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
