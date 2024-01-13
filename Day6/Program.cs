string[] inputLines = await File.ReadAllLinesAsync("input.txt");
Records originalRecords = Records.Create(inputLines[0], inputLines[1]);
Records advancedRecords = Records.CreateOneRace(inputLines[0], inputLines[1]);
long originalAnswer = GetAnswer(originalRecords);
long advancedAnswer = GetAnswer(advancedRecords);
Console.WriteLine(originalAnswer);
Console.WriteLine(advancedAnswer);

int GetAnswer(Records records)
{
    int recordImprovementsMultiplied = 1;
    foreach (KeyValuePair<long, long> race in records.Races)
    {
        int recordImprovementCount = 0;
        for (int speed = 1; speed < race.Key; speed++)
        {
            long timeToMove = race.Key - speed;
            long distance = timeToMove * speed;
            if (distance > race.Value)
            {
                recordImprovementCount++;
            }
        }
        recordImprovementsMultiplied *= recordImprovementCount;
    }
    return recordImprovementsMultiplied;
}
