using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels.Basket
{
    public class CustomerBasketUpdateViewModel
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}
