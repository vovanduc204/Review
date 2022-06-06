﻿using SM.DomainLayer.Core.SharedKernel.Exceptions;
using SM.DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class OrderItem
    {
        public int Id { get; protected set; }

        public int ProductId { get; protected set; }

        public Price Price { get; protected set; }

        public int OrderId { get; protected set; }


        protected OrderItem() // For Entity Framework Core
        {

        }

        public OrderItem(int productId, Price price)
        {
            ProductId = productId;

            Price = price;

            CheckForBrokenRules();
        }

        private void CheckForBrokenRules()
        {
            if (ProductId == 0)
                throw new BusinessRuleBrokenException("You must supply valid Product!");

            if (Price is null)
                throw new BusinessRuleBrokenException("You must supply an Order Item!");
        }
    }
}
