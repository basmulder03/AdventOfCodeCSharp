using AdventOfCode;
using AdventOfCode.ExtensionMethods;
using Shared.Helpers;

namespace _2015.days
{
    internal class Day6 : IDaySolution
    {

        public void SolutionPart1(string data)
        {
            var grid = new Grid<int>(1000, 1000);
            grid.SetAll(0);
            foreach (var line in data.SplitToLines())
            {
                var splitted = line.Split(' ');
                if (splitted.Length > 0)
                {
                    switch (splitted[0])
                    {
                        case "toggle":
                            var coors1array1 = splitted[1].Split(",").Select(n => int.Parse(n));
                            var coors2array1 = splitted[3].Split(",").Select(n => int.Parse(n));
                            var coors11 = new Coordinate<int> { X = coors1array1.First(), Y = coors1array1.Last() };
                            var coors21 = new Coordinate<int> { X = coors2array1.First(), Y = coors2array1.Last() };
                            var toggleGrid = grid.GetSubsection(coors11, coors21);
                            toggleGrid.Map((value) => value == 1 ? 0 : 1);
                            grid.SetSubsection(coors11, toggleGrid);
                            break;
                        case "turn":
                            var coors1array = splitted[2].Split(",").Select(n => int.Parse(n));
                            var coors2array = splitted[4].Split(",").Select(n => int.Parse(n));
                            var coors1 = new Coordinate<int> { X = coors1array.First(), Y = coors1array.Last() };
                            var coors2 = new Coordinate<int> { X = coors2array.First(), Y = coors2array.Last() };
                            switch (splitted[1])
                            {
                                case "on":
                                    var onGrid = new Grid<int>(coors1, coors2);
                                    onGrid.SetAll(1);
                                    grid.SetSubsection(coors1, onGrid);
                                    break;
                                case "off":
                                    var offGrid = new Grid<int>(coors1, coors2);
                                    offGrid.SetAll(0);
                                    grid.SetSubsection(coors1, offGrid);
                                    break;
                            }
                            break;
                    }
                }
            }

            var litLights = 0;

            grid.ForEach((value) =>
            {
                if (value == 1) litLights++;
            });
            Console.WriteLine(litLights);
        }

        public void SolutionPart2(string data)
        {
            var grid = new Grid<int>(1000, 1000);
            grid.SetAll(0);
            foreach (var line in data.SplitToLines())
            {
                var splitted = line.Split(' ');
                if (splitted.Length > 0)
                {
                    switch (splitted[0])
                    {
                        case "toggle":
                            var coors1array1 = splitted[1].Split(",").Select(n => int.Parse(n));
                            var coors2array1 = splitted[3].Split(",").Select(n => int.Parse(n));
                            var coors11 = new Coordinate<int> { X = coors1array1.First(), Y = coors1array1.Last() };
                            var coors21 = new Coordinate<int> { X = coors2array1.First(), Y = coors2array1.Last() };
                            var toggleGrid = grid.GetSubsection(coors11, coors21);
                            toggleGrid.Map(value => value + 2);
                            grid.SetSubsection(coors11, toggleGrid);
                            break;
                        case "turn":
                            var coors1array = splitted[2].Split(",").Select(n => int.Parse(n));
                            var coors2array = splitted[4].Split(",").Select(n => int.Parse(n));
                            var coors1 = new Coordinate<int> { X = coors1array.First(), Y = coors1array.Last() };
                            var coors2 = new Coordinate<int> { X = coors2array.First(), Y = coors2array.Last() };
                            switch (splitted[1])
                            {
                                case "on":
                                    var onGrid = grid.GetSubsection(coors1, coors2);
                                    onGrid.Map(value => value + 1);
                                    grid.SetSubsection(coors1, onGrid);
                                    break;
                                case "off":
                                    var offGrid = grid.GetSubsection(coors1, coors2);
                                    offGrid.Map(value => value > 0 ? value - 1 : 0);
                                    grid.SetSubsection(coors1, offGrid);
                                    break;
                            }
                            break;
                    }
                }
            }

            var litLights = 0;

            grid.ForEach((value) =>
            {
                litLights += value;
            });
            Console.WriteLine(litLights);
        }
    }
}
