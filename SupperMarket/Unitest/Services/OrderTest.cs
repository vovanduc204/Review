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

        public OrderTest()
        {
          
        }

     
    }
}
