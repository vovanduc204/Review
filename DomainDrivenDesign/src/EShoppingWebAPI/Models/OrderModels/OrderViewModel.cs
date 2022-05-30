using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingWebAPI.Models.OrderModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public Guid? TrackingNumber { get; set; }

        public string ShippingAdress { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
    }
}
