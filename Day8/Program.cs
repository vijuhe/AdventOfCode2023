string[] inputLines = await File.ReadAllLinesAsync("input.txt");
TurningInstructions instructions = new(inputLines[0]);
Map map = Map.Create(inputLines);
int turnCount = 0;
while (map.CurrentLocation != "ZZZ")
{
    turnCount++;
    map.Turn(instructions.GetNextDirection());
}
Console.WriteLine(turnCount);
