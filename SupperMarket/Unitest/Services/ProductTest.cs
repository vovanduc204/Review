using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SM.API.Controllers;
using SM.API.Helpers;
using SM.API.ViewModels;
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
    public class ProductTest
    {
        #region Property  
        public Mock<IProductService> mock = new Mock<IProductService>();

        private ProductController controller;

        #endregion
        public ProductTest()
        { 
        }

        [Fact]
        public async void GetListProducsReturnOk()
        {
            // Arrange

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = mockMapper.CreateMapper();
            controller = new ProductController(mock.Object, mapper);

            // Act
            var result = await controller.GetListProducts();
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
