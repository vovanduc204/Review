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
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Product>> ListAsync()
        {
            return _unitOfWork.ProductRepository.GetAllAsync();
        }

        public Product GetById(int id)
        {
            return _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task<Product> SaveAsync(Product product)
        {
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(product.CategoryId); // if category not found in table will be not update
            if (existingCategory!=null)
            {
                if (existingProduct != null)
                {
                    _unitOfWork.ProductRepository.Update(product);
                    await _unitOfWork.CompleteAsync();
                }    
            }      
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            _unitOfWork.ProductRepository.Remove(existingProduct);

            await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            return existingProduct;

        }

    }
}
