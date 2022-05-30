using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingWebAPI.Models.OrderModels
{
    public class OrderSaveRequestModel
    {
        public string ShippingAdress { get; set; }

        public IEnumerable<OrderItemSaveRequestModel> OrderItemsDtoModel { get; set; }
    }
}
