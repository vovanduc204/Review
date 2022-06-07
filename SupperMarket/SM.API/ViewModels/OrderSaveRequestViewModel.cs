using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class OrderSaveRequestViewModel
    {
        public string ShippingAdress { get; set; }

        public IEnumerable<OrderItemSaveRequestViewModel> OrderItemsDtoModel { get; set; }
    }
}
