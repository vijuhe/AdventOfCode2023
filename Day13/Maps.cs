internal class Maps
{
    private readonly List<Map> maps = [];
    private List<string> mapLines = [];

    internal int GetTotalReflectionsSum()
    {
        int sum = 0;
        foreach (var map in maps)
        {
            int? index = map.GetNextVerticalReflectionIndex();
            while (index.HasValue)
            {
                sum += index.Value;
                index = map.GetNextVerticalReflectionIndex();
            }
            index = map.GetNextHorizontalReflectionIndex();
            while (index.HasValue)
            {
                sum += index.Value * 100;
                index = map.GetNextHorizontalReflectionIndex();
            }
        }
        return sum;
    }

    internal void Parse(string line)
    {
        if (line == string.Empty)
        {
            maps.Add(new Map(mapLines.ToArray()));
            mapLines = [];
        }
        else
        {
            mapLines.Add(line);
        }
    }
}