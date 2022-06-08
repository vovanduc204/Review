using AutoMapper;
using Moq;
using SM.API.Controllers;
using SM.API.Helpers;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Unitest.Services
{
    public class OrderTest
    {

        public Mock<IOrderService> mock = new Mock<IOrderService>();
        private static IMapper _mapper;

        public OrderTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
