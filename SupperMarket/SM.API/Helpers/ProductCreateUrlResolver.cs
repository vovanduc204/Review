using AutoMapper;
using Microsoft.Extensions.Configuration;
using SM.API.ViewModels.Product;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Helpers
{
    public class ProductCreateUrlResolver : IValueResolver<Product, CreateProductViewModel, string>
    {
        private readonly IConfiguration _config;
        public ProductCreateUrlResolver(IConfiguration config)
        {
            _config = config;
        }


        public string Resolve(Product source, CreateProductViewModel destination, string destMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
