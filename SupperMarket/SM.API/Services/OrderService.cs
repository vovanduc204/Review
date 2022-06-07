using AutoMapper;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Order> GetById(int id)
        {
            var resource = _unitOfWork.OrderRepository.GetByIdAsync(id);
            return resource;
        }

        public Task<IEnumerable<Order>> ListAsync()
        {
            return _unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order> SaveAsync(Order order)
        {
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
            return order;
        }

        public async Task<Order> UpdateAsync(int id, Order order)
        {
            var existingOrder = await _unitOfWork.OrderRepository.GetByIdAsync(id);

            if (existingOrder != null)
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.CompleteAsync();
            return order;
        }

        public async Task<Order> Delete(int id)
        {
            var existingOrder = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            _unitOfWork.OrderRepository.Remove(existingOrder);

            await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            return existingOrder;
        }

    }
}
