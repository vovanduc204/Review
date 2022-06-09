using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public Mock<IOrderService> _mockOrderService;
        private readonly OrderController _orderController;

        public OrderTest()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = mockMapper.CreateMapper();
            _mockOrderService = new Mock<IOrderService>();
            _orderController = new OrderController(_mockOrderService.Object, mapper);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _orderController.GetListOrders();
            // Act
            okResult.Wait();
            var viewResult = okResult.Result as ViewResult;
            Assert.NotNull(viewResult);
            Assert.Equal("GetListOrders", viewResult.ViewName);
        }


    }
}
