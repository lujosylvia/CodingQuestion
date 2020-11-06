using CodingQuestion.Extensions;
using CodingQuestion.Models;

namespace CodingQuestion.Services
{
    public static class DenominationDataSetExtensions
    {
        public static void GetGreatestProfit(this DenominationDataSet dataSet)
        {
            var denominations = dataSet.Denominations;

            var max = -1;
            var min = 999999;

            for(int i = 0; i < dataSet.NumberOfPrices; i++)
            {
                var price = 0;
                denominations.ForEach(denomination => price += denomination.MultipliedPrices[i]);

                max = (price > max) ? price : max;
                min = (price < min) ? price : min;
            }

            dataSet.HighestDifference = (max - min > 0) ? (max - min) : 0;
        }

        public static void CalculateMultipliers(this DenominationDataSet dataSet)
        {
            var multiplier = 1;
            var denominations = dataSet.Denominations;

            for (int i = denominations.Count - 1; i >= 0; i--)
            {
                denominations[i].Multiplier = multiplier;
                multiplier *= denominations[i].TradeValue;
                denominations[i].CalculateMultipliedPrices();
            }

            dataSet.Denominations = denominations;
        }
    }
}
