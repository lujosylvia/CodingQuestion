using CodingQuestion.Models;
using System.Collections.Generic;

namespace CodingQuestion.Tests
{
    public static class TestData
    {
        public static DenominationDataSet GetTestDataSet()
        {
            var testDataSet = new DenominationDataSet(3, 3);
            testDataSet.Denominations = new List<Denomination>
            {
                new Denomination
                {
                    Index = 0,
                    Multiplier = 15,
                    TradeValue = 1,
                    OriginalPrices = new List<int>{ 1, 3, 1},
                    MultipliedPrices = new List<int>{15, 45, 15}
                },
                new Denomination
                {
                    Index = 1,
                    Multiplier = 5,
                    TradeValue = 3,
                    OriginalPrices = new List<int>{ 1, 0, 10},
                    MultipliedPrices = new List<int>{5, 0, 50}
                },
                new Denomination
                {
                    Index = 2,
                    Multiplier = 1,
                    TradeValue = 5,
                    OriginalPrices = new List<int>{ 1, 0, 0},
                    MultipliedPrices = new List<int>{1, 0, 0}
                }
            };
            testDataSet.HighestDifference = 44;

            return testDataSet;
        }
    }
}
