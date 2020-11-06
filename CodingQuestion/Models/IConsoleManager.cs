
namespace CodingQuestion.Models
{
    public interface IConsoleManager
    {
        int[] ReadMultipleValues(int expectedSize, bool isExact = false);
        int ReadSingleValue();
        void WriteOutput(string output);
        void WriteOutput(int output);
    }
}
