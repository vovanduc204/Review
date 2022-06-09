using SM.DomainLayer.Entities;
using System;
using System.Linq.Expressions;

namespace SM.DomainLayer.Specifications
{
    public class OrderByPaymentIntentWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentWithItemsSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}