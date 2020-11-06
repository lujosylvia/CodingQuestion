using CodingQuestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingQuestion.Services
{
    public class ConsoleService : IConsoleService
    {
        public readonly IConsoleManager _consoleManager;

        public ConsoleService(IConsoleManager consoleManager)
        {
            _consoleManager = consoleManager;
        }

        public ICollection<DenominationDataSet> InputDataSets()
        {
            int numberOfDataSets = _consoleManager.ReadSingleValue();

            return PopulateDataSets(numberOfDataSets);
        }
 
        public void OutputHighestDifferences(ICollection<DenominationDataSet> dataSets)
        {
            var dataSetNumber = 1;
            dataSets.ToList().ForEach((dataSet) =>
            {
                _consoleManager.WriteOutput($"Data Set {dataSetNumber}:");
                _consoleManager.WriteOutput(dataSet.HighestDifference);

                dataSetNumber++;
            });
        }

        public virtual ICollection<DenominationDataSet> PopulateDataSets(int numberOfDataSets)
        {
            ICollection<DenominationDataSet> result = new List<DenominationDataSet>();

            for (int k = 0; k < numberOfDataSets; k++)
            {
                var input = _consoleManager.ReadMultipleValues(2, true);

                var D = input[0];
                var N = input[1];

                var dataSet = new DenominationDataSet(D, N);

                var tradeValues = _consoleManager.ReadMultipleValues(D - 1);

                for (int d = 1; d < dataSet.NumberOfDenominations; d++)
                {
                    var tradeValue = tradeValues[d - 1];
                    dataSet.Denominations[d].TradeValue = tradeValue;
                }

                for (int n = 0; n < N; n++)
                {
                    var prices = _consoleManager.ReadMultipleValues(N);

                    for (int p = 0; p < prices.Length; p++)
                    {
                        dataSet.Denominations[p].OriginalPrices.Add(Convert.ToInt32(prices[p]));
                    }
                }

                result.Add(dataSet);
            }

            return result;
        }
    }
}
