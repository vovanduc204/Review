using SM.DomainLayer.Core.SharedKernel.Exceptions;
using SM.DomainLayer.Core.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class Order
    {
        public Order()
        {

        }
        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail,
          OrderAggregate.Address shipToAddress, DeliveryMethod deliveryMethod,
          decimal subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public int Id { get; private set; }
        public string BuyerEmail { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public OrderAggregate.Address ShipToAddress { get; private set; }
        public DeliveryMethod DeliveryMethod { get; private set; }
        public IReadOnlyList<OrderItem> OrderItems { get; private set; }
        public decimal Subtotal { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; private set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }



    }
}
