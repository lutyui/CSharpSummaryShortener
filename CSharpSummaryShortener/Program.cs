namespace CSharpSummaryShortener
{
    internal class Program
    {
        public class Block
        {
            public bool IsSummary { get; set; } = false;
            public string? Indent { get; set; }
            public List<string> SummaryBodyLines { get; set; } = new();
            public List<string> RawLines { get; set; } = new();
            public string Render()
            {
                if (IsSummary && SummaryBodyLines.Count == 1)
                {
                    return $"{Indent}/// <summary> {SummaryBodyLines.Single()} </summary>";
                }
                else
                {
                    return string.Join("\n", RawLines);
                }
            }
        }

        static void Main(string[] args)
        {
            var inputFilePath = "../../../input.txt";
            var outputFilePath = "../../../output.txt";
            var lines = File.ReadAllLines(inputFilePath);
            var blocks = new List<Block>();
            var currentBlock = new Block();
            bool isInSummary = false;
            foreach (var line in lines)
            {
                currentBlock.RawLines.Add(line);
                if (line.Contains("/// <summary>"))
                {
                    isInSummary = true;
                    currentBlock.IsSummary = true;
                    currentBlock.Indent = line.Replace("/// <summary>", string.Empty);
                }
                else if (line.Contains("/// </summary>"))
                {
                    isInSummary = false;
                    blocks.Add(currentBlock);
                    currentBlock = new();
                }
                else if (isInSummary)
                {
                    currentBlock.SummaryBodyLines.Add(line.Replace($"{currentBlock.Indent}/// ", string.Empty));
                }
                else
                {
                    blocks.Add(currentBlock);
                    currentBlock = new();
                }
            }

            File.WriteAllText(outputFilePath, string.Join("\n", blocks.Select(x => x.Render())));
        }
    }
}