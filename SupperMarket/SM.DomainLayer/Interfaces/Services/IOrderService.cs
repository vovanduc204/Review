using SM.DomainLayer.Entities;
using SM.DomainLayer.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListOrdersAsync();
        Task<Order> UpdateOrderAsync(int id, string buyerEmail, Order order);
        Task<Order> DeleteOrderBy(int id);
        Task<Order> CreateOrderAsync(string buyerEmail, int delieveryMethod, string basketId, Entities.OrderAggregate.Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
