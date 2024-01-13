string[] inputLines = await File.ReadAllLinesAsync("input.txt");
Map map = Map.Create(inputLines);
int maxLocationsLit = 0;

for (int row = 0; row < map.Rows; row++)
{
    map.EnterLight(new LightSnapshot(row, 0, Direction.Right));
    if (map.LocationsLit > maxLocationsLit)
    {
        maxLocationsLit = map.LocationsLit;
    }
    map = Map.Create(inputLines);

    map.EnterLight(new LightSnapshot(row, map.Columns - 1, Direction.Left));
    if (map.LocationsLit > maxLocationsLit)
    {
        maxLocationsLit = map.LocationsLit;
    }
    map = Map.Create(inputLines);
}

for (int column = 0; column < map.Columns; column++)
{
    map.EnterLight(new LightSnapshot(0, column, Direction.Down));
    if (map.LocationsLit > maxLocationsLit)
    {
        maxLocationsLit = map.LocationsLit;
    }
    map = Map.Create(inputLines);

    map.EnterLight(new LightSnapshot(map.Rows - 1, column, Direction.Up));
    if (map.LocationsLit > maxLocationsLit)
    {
        maxLocationsLit = map.LocationsLit;
    }
    map = Map.Create(inputLines);
}

Console.WriteLine(maxLocationsLit);

//map.EnterLight(new LightSnapshot(0, 0, Direction.Right));
//Console.WriteLine(map.LocationsLit);
