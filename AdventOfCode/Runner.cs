namespace AdventOfCode
{
    public static class Runner
    {
        public static void Run(IEnumerable<IDaySolution> solutions, bool testData = true)
        {
            var counter = 0;
            foreach (var solution in solutions)
            {
                var day = solutions.ElementAtOrDefault(counter);
                var dayString = $"day{counter + 1}";
                var data = solution.LoadData(dayString, testData);
                Console.WriteLine($"Executing Day {counter} of {solutions.Count()}");
                if (day != null)
                {
                    Run(day, data);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Oops!, I'm accidently null");
                }
                counter++;
            }
        }

        public static void Run(IEnumerable<IDaySolution> solutions, int runDay, bool testData = true)
        {
            Console.WriteLine($"Executing Day {runDay}");
            var dayString = $"day{runDay}";
            var solution = solutions.ElementAtOrDefault(runDay - 1);
            var data = solution!.LoadData(dayString, testData)!;
            Run(solution!, data);
        }

        public static void Run(IDaySolution solution, string data)
        {
            RunPart1(solution, data);
            RunPart2(solution, data);
        }

        public static void RunPart1(IDaySolution solution, string data)
        {
            Console.Write("Solution Part 1: ");
            solution.SolutionPart1(data);
        }

        public static void RunPart2(IDaySolution solution, string data)
        {
            Console.Write("Solution Part 2: ");
            solution.SolutionPart2(data);
        }
    }
}
