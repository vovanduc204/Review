using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class DeliveryMethod
    {
        public DeliveryMethod()
        {

        }
        public DeliveryMethod(string shortName, string deliveryTime, string description, decimal price)
        {
            ShortName = shortName;
            DeliveryTime = deliveryTime;
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }
        public string ShortName { get; private set; }
        public string DeliveryTime { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

    }
}
