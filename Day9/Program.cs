int sumOfNextNumbers = 0;
await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    History history = History.Create(line);
    sumOfNextNumbers += history.CalculateNextNumber();
}
Console.WriteLine(sumOfNextNumbers);
