using CodingQuestion.Models;
using CodingQuestion.Services;
using System.Linq;

namespace CodingQuestion
{
    class Program
    {

        static void Main(string[] args)
        {
            IConsoleManager _consoleManager = new ConsoleManager();
            IConsoleService _consoleService = new ConsoleService(_consoleManager);

            var dataSets = _consoleService.InputDataSets().ToList();

            dataSets.ToList().ForEach((dataSet) =>
            {
                dataSet.CalculateMultipliers();
                dataSet.GetGreatestProfit();
            });

            _consoleService.OutputHighestDifferences(dataSets);
        }
    }
}
