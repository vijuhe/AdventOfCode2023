int originalSum = 0;
int advancedSum = 0;

string[] lines = await File.ReadAllLinesAsync("input.txt");
EngineSchemaRow[] rows = CreateEngineSchemaRows(lines);

for(int i = 0; i < rows.Length; i++)
{
    EngineSchemaNumber? number = rows[i].GetNextNumber();
    while (number != null)
    {
        bool containsSymbolAbove = i > 0 && rows[i - 1].ContainsSymbols(number.StartIndex - 1, number.Length + 2);
        bool containsSymbolBelow = i < rows.Length - 1 && rows[i + 1].ContainsSymbols(number.StartIndex - 1, number.Length + 2);
        bool containsSymbolInFront = rows[i].ContainsSymbols(number.StartIndex - 1, 1);
        bool containsSymbolAfter = rows[i].ContainsSymbols(number.StartIndex + number.Length, 1);
        if (containsSymbolAbove || containsSymbolBelow || containsSymbolInFront || containsSymbolAfter)
        {
            originalSum += number.Value;
        }
        number = rows[i].GetNextNumber();
    }
}

for (int i = 0; i < rows.Length; i++)
{
    int? gearPosition = rows[i].GetNextGearPosition();
    while (gearPosition != null)
    {
        IEnumerable<int> numbersAbove = i > 0 ? rows[i - 1].GetNumbersTouchingRange(gearPosition.Value - 1, 3) : Enumerable.Empty<int>();
        IEnumerable<int> numbersBelow = i < rows.Length ? rows[i + 1].GetNumbersTouchingRange(gearPosition.Value - 1, 3) : Enumerable.Empty<int>();
        IEnumerable<int> numberToTheLeft = rows[i].GetNumbersTouchingRange(gearPosition.Value - 1, 1);
        IEnumerable<int> numberToTheRight = rows[i].GetNumbersTouchingRange(gearPosition.Value + 1, 1);
        IEnumerable<int> surroundingNumbers = numbersAbove.Concat(numbersBelow).Concat(numberToTheRight).Concat(numberToTheLeft);
        if (surroundingNumbers.Count() == 2)
        {
            int gearRatio = surroundingNumbers.First() * surroundingNumbers.Last();
            advancedSum += gearRatio;
        }
        gearPosition = rows[i].GetNextGearPosition();
    }
}

Console.WriteLine(originalSum);
Console.WriteLine(advancedSum);

EngineSchemaRow[] CreateEngineSchemaRows(string[] lines)
{
    var rows = new EngineSchemaRow[lines.Length];
    for(int i = 0; i < lines.Length; i++)
    {
        EngineSchemaRow row = new(lines[i]);
        rows[i] = row;
    }
    return rows;
}