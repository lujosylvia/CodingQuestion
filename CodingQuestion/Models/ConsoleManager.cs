using System;
using System.Linq;

namespace CodingQuestion.Models
{
    public class ConsoleManager : IConsoleManager
    {
        public int[] ReadMultipleValues(int expectedSize, bool isExact = true)
        {
            var resultValues = Console
                .ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            if(isExact && resultValues.Length != expectedSize)
            {
                throw new ArgumentException("The number of values provided does not match the expected quantity.");
            }
            else if(!isExact && resultValues.Length > expectedSize)
            {
                throw new ArgumentException("The number of values provides is greater than the expected quantity.");
            }

            return resultValues;
        }

        public int ReadSingleValue() => Convert.ToInt32(Console.ReadLine());

        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
        public void WriteOutput(int output)
        {
            Console.WriteLine(output);
        }
    }
}
