using System.Text.RegularExpressions;

internal partial class EngineSchemaRow
{
    private readonly string row;
    private MatchCollection numbers;
    private MatchCollection gears;
    private int numberMatchPosition = 0;
    private int gearMatchPosition = 0;

    public EngineSchemaRow(string row)
    {
        this.row = row;
        numbers = NumberPattern().Matches(row);
        gears = GearPattern().Matches(row);
    }

    internal bool ContainsSymbols(int startIndex, int length)
    {
        int effectiveStartIndex = GetEffectiveStartIndex(startIndex);
        int effectiveLength = GetEffectiveLength(startIndex, length);
        string examinedPart = row.Substring(effectiveStartIndex, effectiveLength);
        return SymbolPattern().IsMatch(examinedPart);
    }

    internal EngineSchemaNumber? GetNextNumber()
    {
        if (numbers.Count == numberMatchPosition)
        {
            return null;
        }

        Match nextNumberMatch = numbers[numberMatchPosition];
        var numberWithPosition = new EngineSchemaNumber(int.Parse(nextNumberMatch.Value), nextNumberMatch.Index, nextNumberMatch.Value.Length);
        numberMatchPosition++;
        return numberWithPosition;
    }

    internal int? GetNextGearPosition()
    {
        if (gears.Count == gearMatchPosition)
        {
            return null;
        }

        Match nextGearMatch = gears[gearMatchPosition];
        gearMatchPosition++;
        return nextGearMatch.Index;
    }

    internal IEnumerable<int> GetNumbersTouchingRange(int startIndex, int length)
    {
        int effectiveStartIndex = GetEffectiveStartIndex(startIndex);
        int effectiveEndIndex = effectiveStartIndex + GetEffectiveLength(startIndex, length) - 1;
        var numbersTouchingRange = numbers.Where(n => (n.Index >= effectiveStartIndex && n.Index <= effectiveEndIndex) 
         || (n.Index + n.Length - 1 >= effectiveStartIndex && n.Index + n.Length - 1 <= effectiveEndIndex));
        return numbersTouchingRange.Select(n => int.Parse(n.Value));
    }

    private int GetEffectiveLength(int startIndex, int length)
    {
        return startIndex + length > row.Length ? row.Length - startIndex : length;
    }

    private static int GetEffectiveStartIndex(int startIndex)
    {
        return startIndex < 0 ? 0 : startIndex;
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberPattern();
    [GeneratedRegex(@"\*")]
    private static partial Regex GearPattern();
    [GeneratedRegex(@"[^\.\d]")]
    private static partial Regex SymbolPattern();
}