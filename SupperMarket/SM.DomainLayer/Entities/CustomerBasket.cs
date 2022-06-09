using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public CustomerBasket(string id, List<BasketItem> items, int? deliveryMethodId, string clientSecret, string paymentIntentId, decimal shippingPrice) : this(id)
        {
            Items = items;
            DeliveryMethodId = deliveryMethodId;
            ClientSecret = clientSecret;
            PaymentIntentId = paymentIntentId;
            ShippingPrice = shippingPrice;
        }

        public string Id { get; private set; }
        public List<BasketItem> Items { get; private set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; private set; }
        public string ClientSecret { get; private set; }
        public string PaymentIntentId { get; private set; }
        public decimal ShippingPrice { get; private set; }
    }
}
