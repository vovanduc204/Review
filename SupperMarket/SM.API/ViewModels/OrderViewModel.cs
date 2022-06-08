using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public Guid? TrackingNumber { get; set; }

        public string ShippingAdress { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderItemViewModel> OrderItemsViewModel { get;}

    }
}
