using AdventOfCode;
using Shared.Crypto;

namespace _2015.days
{
    internal class Day4 : IDaySolution
    {

        public void SolutionPart1(string data)
        {
            var counter = 0;
            while (true)
            {
                counter++;
                var encrypted = MD5.Encrypt($"{data}{counter}");
                if (encrypted.Substring(0, 5) == "00000") break;
            }
            Console.WriteLine(counter);
        }

        public void SolutionPart2(string data)
        {
            var counter = 0;
            while (true)
            {
                var encrypted = MD5.Encrypt($"{data}{++counter}");
                if (encrypted.Substring(0, 6) == "000000") break;
            }
            Console.WriteLine(counter);
        }
    }
}
