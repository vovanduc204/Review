using EShopping.Core.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.UnitTests.ValueObjects
{
    public class MoneySymbolShould
    {
        [Test]
        public void Test_GetSymbol_For_SpecifiedType()
        {
            // act
            var actualResult = MoneySymbols.GetSymbol(Core.Domain.Enums.MoneyUnit.Dollar);

            // assert
            Assert.That(actualResult.Equals("$"));
        }

        [Test]
        public void Test_GetSymbol_For_UnSpecifiedType()
        {
            // act
            var actualResult = MoneySymbols.GetSymbol(Core.Domain.Enums.MoneyUnit.UnSpecified);

            // assert
            Assert.That(actualResult.Equals(string.Empty));
        }
    }
}
