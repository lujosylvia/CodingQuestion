using CodingQuestion.Models;
using CodingQuestion.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodingQuestion.Tests.Extensions
{
    [TestClass]
    public class DenominationDataSetExtensionsTests
    {
        public readonly DenominationDataSet _testDataSet = TestData.GetTestDataSet();

        [TestMethod, TestCategory("Small")]
        public void GetGreatestProfit_NoDifferentPrices_0()
        {
            var testDataSet = TestData.GetTestDataSet();
            testDataSet.NumberOfPrices = 0;

            testDataSet.GetGreatestProfit();

            Assert.AreEqual(0, testDataSet.HighestDifference);
        }

        [TestMethod, TestCategory("Small")]
        public void GetGreatestProfit_DifferentPrices_CorrectAnswer()
        {
            var testDataSet = TestData.GetTestDataSet();

            testDataSet.GetGreatestProfit();

            Assert.AreEqual(_testDataSet.HighestDifference, testDataSet.HighestDifference);
        }

        [TestMethod, TestCategory("Small")]
        public void CalculateMultipliers_MultiplierAndPrices_CorrectAnswer()
        {
            var testDataSet = TestData.GetTestDataSet();

            testDataSet
                .Denominations
                .ForEach(denomination => denomination.MultipliedPrices = new List<int> { });

            testDataSet.CalculateMultipliers();

            for(int i = 0; i < testDataSet.Denominations.Count; i++)
            {
                for(int j = 0; j < testDataSet.Denominations[i].MultipliedPrices.Count; j++)
                {
                    Assert.AreEqual(
                        _testDataSet.Denominations[i].MultipliedPrices[j],
                        testDataSet.Denominations[i].MultipliedPrices[j]
                    );
                }
            }
        }
    }
}
