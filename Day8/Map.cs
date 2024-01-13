using System.Text.RegularExpressions;

internal partial class Map
{
    private string startingLocation;
    private readonly IReadOnlyCollection<Location> locations;

    private Map(string startingLocation, IReadOnlyCollection<Location> locations)
    {
        this.startingLocation = startingLocation;
        CurrentLocation = startingLocation;
        this.locations = locations;
    }

    public string CurrentLocation { get; private set; }

    public void Turn(Direction direction)
    {
        if (direction == Direction.Left)
        {
            CurrentLocation = locations.Single(l => l.Current.Equals(CurrentLocation)).ToTheLeft;
        }
        else
        {
            CurrentLocation = locations.Single(l => l.Current.Equals(CurrentLocation)).ToTheRight;
        }
    }

    internal static Map Create(string[] inputLines)
    {
        List<Location> locations = [];
        string? startingLocation = null;
        foreach (var line in inputLines) 
        {
            Match locationMatch = LocationPattern().Match(line);
            if (locationMatch.Success) 
            {
                if (startingLocation == null)
                {
                    startingLocation = locationMatch.Groups[1].Value;
                }
                var location = new Location(locationMatch.Groups[1].Value, locationMatch.Groups[2].Value, locationMatch.Groups[3].Value);
                locations.Add(location);
            }
        }
        return new Map(startingLocation!, locations);
    }

    [GeneratedRegex(@"(\w{3}) = \((\w{3}), (\w{3})\)")]
    private static partial Regex LocationPattern();

    private record Location(string Current, string ToTheLeft, string ToTheRight)
    {
    }
}