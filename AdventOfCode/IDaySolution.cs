namespace AdventOfCode
{
    public interface IDaySolution
    {
        /// <summary>
        /// The solution for part 1 of the Advent Of Code puzzle.
        /// </summary>
        public void SolutionPart1(string data);

        /// <summary>
        /// The solution for part 2 of the Advent Of Code puzzle.
        /// </summary>
        public void SolutionPart2(string data);

        public string LoadData(string day, bool testData = true)
        {
            var path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory)!, "../", "../", "data", day, (testData) ? "sample.txt" : "data.txt");

            try
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                string fileContents;
                using (var reader = new StreamReader(fileStream))
                {
                    fileContents = reader.ReadToEnd();
                }
                return fileContents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("File Not Found");
                return "";
            }
        }
    }
}
