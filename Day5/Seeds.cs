using System.Text.RegularExpressions;

internal partial class Seeds
{
    public Seeds(IEnumerable<long> seedIds)
    {
        Ids = seedIds;
    }

    public IEnumerable<long> Ids { get; }

    internal static Seeds Create(string input)
    {
        MatchCollection seedNumbers = NumbersPattern().Matches(input);
        return new Seeds(seedNumbers.Select(seed => long.Parse(seed.Value)));
    }

    internal static Seeds CreateWithRanges(string input)
    {
        throw new NotImplementedException();
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersPattern();
}