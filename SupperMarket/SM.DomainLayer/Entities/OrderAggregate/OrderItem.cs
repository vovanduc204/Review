using SM.DomainLayer.Core.SharedKernel.Exceptions;
using SM.DomainLayer.Entities.OrderAggregate;
using SM.DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public ProductItemOrdered ItemOrdered { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
