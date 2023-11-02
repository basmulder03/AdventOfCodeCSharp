using AdventOfCode;
using AdventOfCode.ExtensionMethods;
using Shared.Extensions;
using Shared.Helpers;

namespace _2015.days
{
    internal class Day2 : IDaySolution
    {

        public void SolutionPart1(string data)
        {
            var lines = data.SplitToLines();
            var totalPaper = 0;
            foreach (var line in lines)
            {
                var dims = Dimension<int>.FromString(line, "x");
                var paper = new int[] {
                    dims.X * dims.Y,
                    dims.Y * dims.Z,
                    dims.X * dims.Z
                };
                totalPaper += paper.Select(d => d * 2).Sum() + paper.Min();
            }
            Console.WriteLine(totalPaper);
        }

        public void SolutionPart2(string data)
        {
            var lines = data.SplitToLines();
            var totalLint = 0;
            foreach (var line in lines)
            {
                var dims = Dimension<int>.FromString(line, "x");
                var intDim = dims.ToList();
                var sorted = intDim.OrderBy(i => i).ToList();
                var smallestTwo = sorted.GetRange(0, 2);
                totalLint += smallestTwo.Select(st => st * 2).Sum() + sorted.Mult();
            }
            Console.WriteLine(totalLint);
        }
    }
}
