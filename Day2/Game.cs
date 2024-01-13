using System.Text.RegularExpressions;

internal partial class Game
{
    private readonly IReadOnlyCollection<Revelation> revelations;

    public Game(byte id, IReadOnlyCollection<Revelation> revelations)
    {
        Id = id;
        this.revelations = revelations;
    }

    internal byte Id { get; }

    internal static Game Create(string gameInput)
    {
        Match gameInputMatch = GameInputFormat().Match(gameInput);
        string[] revelationsInput = gameInputMatch.Groups[2].Value.Split("; ");
        IReadOnlyCollection<Revelation> revelations = CreateRevalations(revelationsInput);
        byte gameId = byte.Parse(gameInputMatch.Groups[1].Value);
        return new Game(gameId, revelations);
    }

    internal bool IsPossible(int redBalls, int greenBalls, int blueBalls)
    {
        return revelations.All(r => r.IsPossible(redBalls, greenBalls, blueBalls));
    }

    internal int GetMinimumBallMultiplication()
    {
        byte minRedBallsRevealed = GetMaxRedBallsRevealed("red");
        byte minGreenBallsRevealed = GetMaxRedBallsRevealed("green");
        byte minBlueBallsRevealed = GetMaxRedBallsRevealed("blue");
        return minRedBallsRevealed * minGreenBallsRevealed * minBlueBallsRevealed;
    }

    private byte GetMaxRedBallsRevealed(string color)
    {
        return revelations.Max(r => r.GetBalls(color));
    }

    private static IReadOnlyCollection<Revelation> CreateRevalations(string[] revelationsInput)
    {
        List<Revelation> revelations = [];
        foreach (string input in revelationsInput)
        {
            Revelation revelation = new(input);
            revelations.Add(revelation);
        }
        return revelations;
    }

    [GeneratedRegex(@"Game (\d+): (.+)")]
    private static partial Regex GameInputFormat();
}