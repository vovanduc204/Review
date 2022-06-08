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
           
            CreateMap<CreateProductViewModel, Product>();

            CreateMap<CategoryViewModel, Category>();

            CreateMap<CreateProductViewModel, Product>()
            .ForMember(des => des.QuantityInPackage, 
            act => act.MapFrom(src => src.Quantity));

            CreateMap<Product, ProductViewModel>()
            .ForMember(des => des.QuantityInPackage,
            act => act.MapFrom(src => src.QuantityInPackage))
            .ForMember(des => des.UnitOfMeasurement,
            act => act.MapFrom(src => src.UnitOfMeasurement));

            CreateMap<OrderSaveRequestViewModel, Order>()
           .ConstructUsing((src, res) =>
           {
               return new Order(src.ShippingAdress, orderItems: res.Mapper.Map<IEnumerable<OrderItem>>(src.OrderItemsDtoModel)
               );
           });

            CreateMap<OrderViewModel, Order>();


            CreateMap<OrderItem, OrderItemViewModel>();

            CreateMap<OrderItemSaveRequestViewModel, OrderItem>();

            CreateMap<PriceSaveRequestViewModel, Price>()
            .ConvertUsing(x => new Price(x.Amount.Value, x.Unit.Value));
        }
    }
}
