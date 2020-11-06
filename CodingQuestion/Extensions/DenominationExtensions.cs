using CodingQuestion.Models;
using System.Collections.Generic;

namespace CodingQuestion.Extensions
{
    public static class DenominationExtensions
    {
        public static void CalculateMultipliedPrices(this Denomination denomination)
        {
            denomination.MultipliedPrices = new List<int> { };

            denomination.OriginalPrices.ForEach(price =>
            {
                denomination.MultipliedPrices.Add(price * denomination.Multiplier);
            });
        }
    }
}
