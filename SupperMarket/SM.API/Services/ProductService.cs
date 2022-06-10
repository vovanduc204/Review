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

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Repository<Product>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await _unitOfWork.Repository<Product>().ListAllAsync();
        }

        public Product SaveProductAsync(Product product)
        {
            _unitOfWork.Repository<Product>().Add(product);
            _unitOfWork.CompleteAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var productExisting = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if(productExisting != null)
            {
                _unitOfWork.Repository<Product>().Update(productExisting);
                await _unitOfWork.CompleteAsync();
            }
            return productExisting;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var productExisting = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            _unitOfWork.Repository<Product>().Delete(productExisting);
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return productExisting;
        }

    }
}
