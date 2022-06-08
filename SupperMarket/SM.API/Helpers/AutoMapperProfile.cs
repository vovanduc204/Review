using AutoMapper;
using SM.API.ViewModels;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Entities;
using SM.DomainLayer.ValueObjects;
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
            CreateMap<Category, CategoryViewModel>();

            CreateMap<CategoryViewModel, Category>()
            .ForMember(des => des.Products,
            act => act.Ignore());

            CreateMap<CreateProductViewModel, Product>()
            .ForMember(des => des.Category,
            act => act.MapFrom(src => src.CategoryViewModel));

            CreateMap<Product, ProductViewModel>();

            CreateMap<OrderSaveRequestViewModel, Order>()
           .ConstructUsing((src, res) =>
           {
               return new Order(src.ShippingAdress, orderItems: res.Mapper.Map<IEnumerable<OrderItem>>(src.OrderItemsDtoModel)
               );
           })
           .ForMember(des => des.OrderItems,
            act => act.Ignore());

            CreateMap<OrderViewModel, Order>()
            .ForMember(des => des.OrderItems,
            act => act.Ignore());

            CreateMap<PriceSaveRequestViewModel, Price>()
            .ConvertUsing(x => new Price(x.Amount.Value, x.Unit.Value));
        }
    }
}
