using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class BasketItem
    {
        public BasketItem(int id, string productName, decimal price, int quantity, string pictureUrl, string category)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
            Category = category;
        }

        public BasketItem()
        {
        }

        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string PictureUrl { get; private set; }
        public string Category { get; private set; }
    }
}
