using AdventOfCode;
using System.Text.RegularExpressions;

namespace _2015.days
{
    internal class Day7 : IDaySolution
    {
        private Dictionary<string, ushort> wireSignals = new();
        private readonly Dictionary<string, string> circuit = new();

        private void InitializeCircuit(string data)
        {
            foreach (var line in data.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                string[] parts = line.Replace("\r", "").Split(" -> ");
                string expression = parts[0];
                string wire = parts[1];
                circuit[wire] = expression;
            }
        }

        private ushort GetWireSignal(string wire)
        {
            if (ushort.TryParse(wire, out var result)) return result;

            if (!wireSignals.ContainsKey(wire))
            {
                string expression = circuit[wire];

                if (ushort.TryParse(expression, out ushort signal))
                {
                    wireSignals[wire] = signal;
                }
                else if (expression.Contains("AND"))
                {
                    Match match = Regex.Match(expression, @"(\w+) AND (\w+)");
                    string left = match.Groups[1].Value;
                    string right = match.Groups[2].Value;
                    wireSignals[wire] = (ushort)(GetWireSignal(left) & GetWireSignal(right));
                }
                else if (expression.Contains("OR"))
                {
                    Match match = Regex.Match(expression, @"(\w+) OR (\w+)");
                    string left = match.Groups[1].Value;
                    string right = match.Groups[2].Value;
                    wireSignals[wire] = (ushort)(GetWireSignal(left) | GetWireSignal(right));
                }
                else if (expression.Contains("LSHIFT"))
                {
                    Match match = Regex.Match(expression, @"(\w+) LSHIFT (\d+)");
                    string left = match.Groups[1].Value;
                    int shift = int.Parse(match.Groups[2].Value);
                    wireSignals[wire] = (ushort)(GetWireSignal(left) << shift);
                }
                else if (expression.Contains("RSHIFT"))
                {
                    Match match = Regex.Match(expression, @"(\w+) RSHIFT (\d+)");
                    string left = match.Groups[1].Value;
                    int shift = int.Parse(match.Groups[2].Value);
                    wireSignals[wire] = (ushort)(GetWireSignal(left) >> shift);
                }
                else if (expression.Contains("NOT"))
                {
                    string operand = expression.Substring(4);
                    wireSignals[wire] = (ushort)~GetWireSignal(operand);
                }
                else
                {
                    wireSignals[wire] = GetWireSignal(expression);
                }
            }

            return wireSignals[wire];
        }

        public void SolutionPart1(string data)
        {
            InitializeCircuit(data);
            Console.WriteLine(GetWireSignal("a"));
        }

        public void SolutionPart2(string data)
        {
            circuit["b"] = wireSignals["a"].ToString();
            wireSignals = new();
            Console.WriteLine(GetWireSignal("a"));
        }
    }
}
