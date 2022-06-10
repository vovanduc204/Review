using Microsoft.Extensions.Caching.Memory;
using SM.DomainLayer.Comunication.Request;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       

    }
}
