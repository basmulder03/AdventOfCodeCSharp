namespace AdventOfCode.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string[] SplitToLines(this string str)
        {
            return str.Split("\n");
        }
    }
}
