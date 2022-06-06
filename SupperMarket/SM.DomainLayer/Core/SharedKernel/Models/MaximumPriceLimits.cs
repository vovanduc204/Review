﻿using SM.DomainLayer.Core.SharedKernel.Exceptions;
using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Core.SharedKernel.Models
{
    public static class MaximumPriceLimits
    {
        private static Dictionary<MoneyUnit, int> _maximumPriceLimits;

        static MaximumPriceLimits()
        {
            if (_maximumPriceLimits != null)
                return;

            _maximumPriceLimits = new Dictionary<MoneyUnit, int>
            {
                { MoneyUnit.Euro, 9000 },

                { MoneyUnit.Dollar, 10000 },

                { MoneyUnit.Rial, 100000 },
            };
        }


        public static int GetMaximumPriceLimit(MoneyUnit unit)
        {
            if (unit == MoneyUnit.UnSpecified)
                throw new BusinessRuleBrokenException("Money Unit is not defined !");

            return _maximumPriceLimits[unit];
        }
    }
}
