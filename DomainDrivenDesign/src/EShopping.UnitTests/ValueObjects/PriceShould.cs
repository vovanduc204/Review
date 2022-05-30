using EShopping.Core.Domain.Enums;
using EShopping.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.UnitTests.ValueObjects
{
    public class PriceShould
    {
        [Test]
        public void Test_ToString_For_SpecifiedUnitType()
        {
            // arrange
            var price = new Price(14, MoneyUnit.Dollar);

            // act
            var actualResult = price.ToString();

            // assert
            Assert.That(actualResult.Equals("14 $"));
        }
    }
}
