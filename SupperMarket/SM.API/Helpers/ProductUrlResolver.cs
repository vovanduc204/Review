using AutoMapper;
using Microsoft.Extensions.Configuration;
using SM.API.ViewModels.Product;
using SM.DomainLayer.Entities;

namespace SM.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductViewModel, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductViewModel destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}