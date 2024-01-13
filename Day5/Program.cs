string[] inputLines = await File.ReadAllLinesAsync("input.txt");
Seeds originalSeeds = Seeds.Create(inputLines[0]);
Seeds advancedSeeds = Seeds.CreateWithRanges(inputLines[0]);
IReadOnlyCollection<Map> maps = ReadMaps(inputLines);
IReadOnlyCollection<long> locations = GetSeedLocations(originalSeeds, maps);
Console.WriteLine(locations.Min());

IReadOnlyCollection<long> GetSeedLocations(Seeds seeds, IReadOnlyCollection<Map> maps)
{
    List<long> locations = [];
    Map seedMap = maps.Single(m => m.From.Equals("seed"));

    foreach (long seedId in seeds.Ids)
    {
        string destination = seedMap.To;
        long destinationId = seedMap.GetDestinationId(seedId);
        while (destination != "location")
        {
            Map nextMap = maps.Single(m => m.From.Equals(destination));
            destination = nextMap.To;
            destinationId = nextMap.GetDestinationId(destinationId);
        }
        locations.Add(destinationId);
    }
    return locations;
}

IReadOnlyCollection<Map> ReadMaps(string[] inputLines)
{
    List<Map> maps = [];
    Map? currentMap = null;
    foreach (string line in inputLines)
    {
        if (Map.StartsNew(line))
        {
            currentMap = Map.Create(line);
            maps.Add(currentMap);
        }
        else
        {
            currentMap?.AddMapping(line);
        }
    }
    return maps;
}