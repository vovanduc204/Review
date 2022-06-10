using AutoMapper;
using SM.API.ViewModels.Address;
using SM.API.ViewModels.Basket;
using SM.API.ViewModels.Category;
using SM.API.ViewModels.Order;
using SM.API.ViewModels.Product;
using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();

            CreateMap<Product, CreateProductViewModel>()
            .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.Category.Id))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductCreateUrlResolver>()).ReverseMap();

            CreateMap<Product, ProductViewModel>()
               .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
               .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<CustomerBasketUpdateViewModel, CustomerBasket>();
            CreateMap<BasketItemViewModel, BasketItem>();
            CreateMap<AddressViewModel, DomainLayer.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderReturnViewModel>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
