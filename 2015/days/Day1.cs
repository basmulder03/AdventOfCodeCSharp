using AdventOfCode;

namespace _2015.days
{
    internal class Day1 : IDaySolution
    {
        public void SolutionPart1(string data)
        {
            var splitData = data.ToCharArray();

            var currentFloor = 0;
            foreach (var c in splitData)
            {
                switch (c)
                {
                    case '(':
                        currentFloor++;
                        break;
                    case ')':
                        currentFloor--;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(currentFloor);
        }

        public void SolutionPart2(string data)
        {
            var splitData = data.ToCharArray();

            var currentFloor = 0;
            var charCounter = 0;
            foreach (var c in splitData)
            {
                charCounter++;
                switch (c)
                {
                    case '(':
                        currentFloor++;
                        break;
                    case ')':
                        currentFloor--;
                        break;
                    default:
                        break;
                }
                if (currentFloor == -1)
                {
                    Console.WriteLine(charCounter);
                    return;
                }
            }
            Console.WriteLine("Basement not reached");
        }
    }
}
