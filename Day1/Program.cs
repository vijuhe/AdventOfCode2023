using System.Text.RegularExpressions;

int originalSum = 0;
int advancedSum = 0;

await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    originalSum += ParseForOriginalSum(line);
    advancedSum += ParseForAdvancedSum(line);
}

Console.WriteLine($"Original answer: {originalSum}");
Console.WriteLine($"Advanced answer: {advancedSum}");

int ParseForAdvancedSum(string line)
{
    var numberIndexes = new Dictionary<int, string>();
    for (int i = 1; i < 10;  i++)
    {
        MatchCollection textMatches = Regex.Matches(line, ToText(i));
        MatchCollection numberMatches = Regex.Matches(line, i.ToString());
        foreach (Match match in textMatches.Concat(numberMatches))
        {
            numberIndexes[match.Index] = i.ToString();
        }
    }
    
    string firstNumber = numberIndexes[numberIndexes.Keys.Min()];
    string lastNumber = numberIndexes[numberIndexes.Keys.Max()];
    return int.Parse(firstNumber + lastNumber);
}

string ToText(int digit)
{
    return digit switch
    {
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => throw new ArgumentOutOfRangeException($"Unexpected digit {digit}")
    };
}

int ParseForOriginalSum(string line)
{
    MatchCollection matches = OriginalInputLineFormat().Matches(line);
    return int.Parse(matches[0].Value + matches[^1].Value);
}

partial class Program
{
    [GeneratedRegex(@"(\d)")]
    private static partial Regex OriginalInputLineFormat();
}
