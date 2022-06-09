using SM.DomainLayer.Core.SharedKernel.Exceptions;
using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.ValueObjects
{
    [ComplexType]
    public class Price
    {
        protected Price()
        {

        }

        public Price(int amount, MoneyUnit unit)
        {
            if (MoneyUnit.UnSpecified == unit)
                throw new BusinessRuleBrokenException("You must supply a valid money unit!");

            Amount = amount;

            Unit = unit;
        }


        public int Amount { get; protected set; }


        public MoneyUnit Unit { get; set; } = MoneyUnit.UnSpecified;


        public bool HasValue
        {
            get
            {
                return (Unit != MoneyUnit.UnSpecified);
            }
        }


        public override string ToString()
        {
            return
                Unit != MoneyUnit.UnSpecified ?
                Amount + " " + MoneySymbols.GetSymbol(Unit) :
                Amount.ToString();
        }
    }
}
