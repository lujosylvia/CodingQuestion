using System;
using System.Collections.Generic;
using System.Text;

namespace CodingQuestion.Models
{
    public class DenominationDataSet
    {
        public List<Denomination> Denominations { get; set; }
        public int NumberOfDenominations { get; set; }
        public int NumberOfPrices { get; set; }
        public int HighestDifference { get; set; } = 0;

        public DenominationDataSet(int denominationSize, int priceSize)
        {
            NumberOfDenominations = denominationSize;
            NumberOfPrices = priceSize;

            Denominations = new List<Denomination>(denominationSize);

            for(int i = 0; i < denominationSize; i++)
            {
                Denominations.Add(new Denomination
                {
                    Index = i,
                    OriginalPrices = new List<int>(priceSize),
                    MultipliedPrices = new List<int>(priceSize),
                });
            }
        }
    }
}
