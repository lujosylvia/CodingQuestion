using CodingQuestion.Extensions;
using CodingQuestion.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingQuestion.Tests.Extensions
{
    [TestClass]
    public class DenominationExtensions
    {
        [TestMethod, TestCategory("Small")]
        public void CalculateMultipliedPrices_PricesAvailable_CalculatesCorrectMultipliedPrices()
        {

            var testDenomination = new Denomination
            {
                Index = 0,
                Multiplier = 3,
                TradeValue = 5,
                OriginalPrices = new List<int> { 1, 5, 7 }
            };

            var expectedMultipliedPrices = new List<int> { 3, 15, 21 };

            testDenomination.CalculateMultipliedPrices();

            for(int i = 0; i < expectedMultipliedPrices.Count; i++)
            {
                Assert.AreEqual(expectedMultipliedPrices[i], testDenomination.MultipliedPrices[i]);
            }
        }

        [TestMethod, TestCategory("Small")]
        public void CalculateMultipliedPrices_NoPricesAvailable_EmptyArray()
        {
            var testDenomination = new Denomination
            {
                Index = 0,
                Multiplier = 3,
                TradeValue = 5,
                OriginalPrices = new List<int> { }
            };

            testDenomination.CalculateMultipliedPrices();

            Assert.AreEqual(0, testDenomination.MultipliedPrices.Count);
        }
    }
}
