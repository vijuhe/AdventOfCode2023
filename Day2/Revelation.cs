using System.Text.RegularExpressions;

internal partial class Revelation
{
    private Dictionary<string, byte> ballsOfColor = [];

    public Revelation(string revelationInput)
    {
        MatchCollection matches = RevelationInputFormat().Matches(revelationInput);
        foreach (Match match in matches)
        {
            byte ballCount = byte.Parse(match.Groups[1].Value);
            string color = match.Groups[2].Value;
            ballsOfColor[color] = ballCount;
        }
    }

    internal bool IsPossible(int redBalls, int greenBalls, int blueBalls)
    {
        return DoesNotExceed("red", redBalls) && DoesNotExceed("green", greenBalls) && DoesNotExceed("blue", blueBalls);
    }

    internal byte GetBalls(string color)
    {
        return ballsOfColor.TryGetValue(color, out byte value) ? value : (byte) 0;
    }

    private bool DoesNotExceed(string color, int count)
    {
        return !ballsOfColor.ContainsKey(color) || ballsOfColor[color] <= count;
    }

    [GeneratedRegex(@"\s?(\d+) (\w+)")]
    private static partial Regex RevelationInputFormat();
}