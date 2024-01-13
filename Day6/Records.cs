using System.Text.RegularExpressions;

internal partial class Records
{
    public Dictionary<long, long> Races { get; } = [];

    public Records(long[] times, long[] distances)
    {
        for (int i = 0; i < times.Length; i++)
        {
            Races[times[i]] = distances[i];
        }
    }

    internal static Records Create(string timesInput, string distancesInput)
    {
        MatchCollection timeNumbers = NumbersPattern().Matches(timesInput);
        MatchCollection distanceNumbers = NumbersPattern().Matches(distancesInput);
        return new Records(timeNumbers.Select(t => long.Parse(t.Value)).ToArray(), distanceNumbers.Select(d => long.Parse(d.Value)).ToArray());
    }

    internal static Records CreateOneRace(string timesInput, string distancesInput)
    {
        return Create(timesInput.Replace(" ", string.Empty), distancesInput.Replace(" ", string.Empty));
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersPattern();
}