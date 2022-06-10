using SM.API.ViewModels.Category;
using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ProductViewModel()
        {
        }
    }

    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get;  set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }
}
