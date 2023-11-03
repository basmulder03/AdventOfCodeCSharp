using AdventOfCode;
using AdventOfCode.ExtensionMethods;

namespace _2015.days
{
    internal class Day5 : IDaySolution
    {

        public void SolutionPart1(string data)
        {
            char[] vowels =
            {
                'a', 'e', 'i',  'o', 'u'
            };
            string[] disallowedCombinations =
            {
                "ab", "cd", "pq", "xy"
            };

            var lines = data.SplitToLines();

            var niceCounter = 0;
            foreach (var line in lines)
            {
                var vowelCounter = 0;
                var doubleLetterCounter = 0;

                var lastLetter = ' ';
                foreach (var c in line)
                {
                    if (vowels.Contains(c)) vowelCounter++;
                    if (c == lastLetter) doubleLetterCounter++;
                    lastLetter = c;
                }
                if (!disallowedCombinations.Any(c => line.Contains(c)) && vowelCounter >= 3 && doubleLetterCounter >= 1) niceCounter++;
            }

            Console.WriteLine(niceCounter);


        }

        public void SolutionPart2(string data)
        {
            var niceCounter = 0;
            foreach (var line in data.SplitToLines())
            {
                var lastLetter = ' ';
                var secondToLastLetter = ' ';

                List<string> letterCombinations = new();

                var doubleLetterCounter = 0;
                var sandwichedLetterCounter = 0;

                var counter = 0;
                foreach (var c in line)
                {
                    if (c == secondToLastLetter) sandwichedLetterCounter++;

                    if (counter + 1 < line.Length)
                    {
                        var sub = line.Substring(counter, 2);
                        if (letterCombinations.Contains(sub) && sub != letterCombinations.LastOrDefault("")) doubleLetterCounter++;
                        letterCombinations.Add(sub);
                    }


                    secondToLastLetter = lastLetter;
                    lastLetter = c;
                    counter++;
                }
                if (doubleLetterCounter >= 1 && sandwichedLetterCounter >= 1) niceCounter++;
            }

            Console.WriteLine(niceCounter);
        }
    }
}
