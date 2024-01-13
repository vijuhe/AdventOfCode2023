string[] inputLines = await File.ReadAllLinesAsync("input.txt");
Map map = Map.Create(inputLines);
for (int i = 0; i < 64; i++)
{
    map.TakeNextSteps();
}
Console.WriteLine(map.CurrentPossibleDestinationsCount);