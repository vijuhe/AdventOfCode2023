int originalSum = 0;
int advancedSum = 0;

await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    Game game = Game.Create(line);
    advancedSum += game.GetMinimumBallMultiplication();
    if (game.IsPossible(12, 13, 14))
    {
        originalSum += game.Id;
    }
}

Console.WriteLine(originalSum); 
Console.WriteLine(advancedSum);