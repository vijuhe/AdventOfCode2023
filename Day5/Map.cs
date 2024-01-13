using System.Net.Sockets;
using System.Text.RegularExpressions;

internal partial class Map
{
    private List<MapIdRange> idMap = [];

    public Map(string from, string to)
    {
        From = from;
        To = to;
    }

    public string From { get; }
    public string To { get; }

    internal static Map Create(string line)
    {
        Match mapDefinition = MapStartPattern().Match(line);
        return new Map(mapDefinition.Groups[1].Value, mapDefinition.Groups[2].Value);
    }

    internal static bool StartsNew(string line)
    {
        return MapStartPattern().IsMatch(line);
    }

    internal void AddMapping(string line)
    {
        MatchCollection numbers = NumbersPattern().Matches(line);
        if (numbers.Count > 0)
        {
            long destinationRangeStart = long.Parse(numbers[0].Value);
            long sourceRangeStart = long.Parse(numbers[1].Value);
            long rangeLength = long.Parse(numbers[2].Value);
            idMap.Add(new MapIdRange(sourceRangeStart, destinationRangeStart, rangeLength));
        }
    }

    internal long GetDestinationId(long sourceId)
    {
        MapIdRange? mapItem = idMap.SingleOrDefault(m => m.SourceIdsStart <= sourceId && m.SourceIdsStart + m.Length >= sourceId);
        if (mapItem == null)
        {
            return sourceId;
        }
        long offset = sourceId - mapItem.SourceIdsStart;
        return mapItem.DestinationIdsStart + offset;
    }

    [GeneratedRegex(@"(\w+)-to-(\w+) map:")]
    private static partial Regex MapStartPattern();
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersPattern();

    private record MapIdRange(long SourceIdsStart, long DestinationIdsStart, long Length)
    {
    }
}