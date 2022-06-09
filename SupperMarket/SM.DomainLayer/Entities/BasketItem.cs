using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class BasketItem
    {
        public BasketItem(int id, string productName, decimal price, int quantity, string pictureUrl, string brand, string type)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
            Brand = brand;
            Type = type;
        }

        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string PictureUrl { get; private set; }
        public string Brand { get; private set; }
        public string Type { get; private set; }
    }
}
