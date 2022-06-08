using SM.DomainLayer.Enums;
using SM.DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Unitest.Values
{
    public class PriceShould
    {
        [Fact]
        public void Price_To_String_For_SpecificUnit()
        {
            // arrange
            var price = new Price(14, MoneyUnit.Dollar);

            // act
            var actualResult = price.ToString();

            // assert
            Assert.True(actualResult.Equals("14 $"));
        }
    }
}
