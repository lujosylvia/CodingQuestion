using System.Collections.Generic;

namespace CodingQuestion.Models
{
    public class Denomination
    {
        public int Index { get; set; }
        public int TradeValue { get; set; }
        public int Multiplier { get; set; }
        public List<int> OriginalPrices { get; set; }
        public List<int> MultipliedPrices { get; set; }
    }
}
