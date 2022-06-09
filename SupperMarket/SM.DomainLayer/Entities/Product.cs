using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id)
        {
            Id = id;
        }

        public Product(int id, string name, string description, decimal price, string pictureUrl, int categoryId, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            CategoryId = categoryId;
            Category = category;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

       
    }
}
