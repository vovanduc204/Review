using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class OrderSaveRequestViewModel
    {
        public int Id { get; private set; }

        public Guid? TrackingNumber { get; private set; }

        public DateTime OrderDate { get; private set; }

        public string ShippingAdress { get; set; }

        public IEnumerable<OrderItemSaveRequestViewModel> OrderItemsDtoModel { get; }

    }
}
