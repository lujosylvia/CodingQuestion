using CodingQuestion.Models;
using System.Collections.Generic;

namespace CodingQuestion.Services
{
    public interface IConsoleService
    {
        ICollection<DenominationDataSet> InputDataSets();
        void OutputHighestDifferences(ICollection<DenominationDataSet> dataSets);
    }
}
