using AdventOfCode;
using Shared.Helpers;

namespace _2015.days
{
    internal class Day3 : IDaySolution
    {
        private Coordinate<int> MovePlayer(Coordinate<int> toMove, char direction)
        {
            return direction switch
            {
                '^' => new Coordinate<int> { X = toMove.X, Y = toMove.Y + 1 },
                '>' => new Coordinate<int> { X = toMove.X + 1, Y = toMove.Y },
                'v' => new Coordinate<int> { X = toMove.X, Y = toMove.Y - 1 },
                '<' => new Coordinate<int> { X = toMove.X - 1, Y = toMove.Y },
                _ => toMove
            };
        }

        public void SolutionPart1(string data)
        {
            var chars = data.ToCharArray();
            var visited = new HashSet<Coordinate<int>>();
            var current = new Coordinate<int>
            {
                X = 0,
                Y = 0
            };
            visited.Add(current);
            foreach (var c in chars)
            {
                current = MovePlayer(current, c);
                visited.Add(current);
            }
            Console.WriteLine(visited.Count);
        }

        public void SolutionPart2(string data)
        {
            var chars = data.ToCharArray();
            var visited = new HashSet<Coordinate<int>>();
            var santa = new Coordinate<int>
            {
                X = 0,
                Y = 0
            };
            var robotSanta = new Coordinate<int>
            {
                X = 0,
                Y = 0
            };
            visited.Add(santa);

            for (var i = 0; i < chars.Length; i += 2)
            {
                santa = MovePlayer(santa, chars[i]);
                if (i + 1 < chars.Length)
                {
                    robotSanta = MovePlayer(robotSanta, chars[i + 1]);
                }
                visited.Add(santa);
                visited.Add(robotSanta);
            }
            Console.WriteLine(visited.Count);
        }
    }
}
