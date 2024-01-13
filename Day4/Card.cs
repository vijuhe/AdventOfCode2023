using System.Text.RegularExpressions;

internal partial class Card
{
    private readonly IEnumerable<int> winningNumbers;
    private readonly IEnumerable<int> myNumbers;

    public int SequenceNumber { get; }

    public Card(int sequenceNumber, IEnumerable<int> winningNumbers, IEnumerable<int> myNumbers)
    {
        SequenceNumber = sequenceNumber;
        this.winningNumbers = winningNumbers;
        this.myNumbers = myNumbers;
    }

    internal static Card Create(string input)
    {
        var inputLineMatch = InputLinePattern().Match(input);
        var numbers = inputLineMatch.Groups[2].Value.Split('|');
        var winningNumbers = NumberPattern().Matches(numbers[0]);
        var myNumbers = NumberPattern().Matches(numbers[1]);
        return new Card(int.Parse(inputLineMatch.Groups[1].Value), winningNumbers.Select(n => int.Parse(n.Value)), myNumbers.Select(n => int.Parse(n.Value)));
    }

    internal int GetWinningNumberCount()
    {
        return myNumbers.Count(n => winningNumbers.Contains(n));
    }

    [GeneratedRegex(@"Card\s+(\d+): (.+)")]
    private static partial Regex InputLinePattern();
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberPattern();
}