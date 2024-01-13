internal class Map(IItem[,] items)
{
    internal int LocationsLit { get; private set; }

    internal static Map Create(string[] inputLines)
    {
        IItem[,] items = new IItem[inputLines.Length, inputLines[0].Length];
        for (int i = 0; i < inputLines.Length; i++)
        {
            for (int j = 0; j < inputLines[i].Length; j++)
            {
                switch (inputLines[i][j])
                {
                    case '.':
                        items[i, j] = new EmptySpace(i, j);
                        break;
                    case '/':
                    case '\\':
                        items[i, j] = new Mirror(i, j, inputLines[i][j]);
                        break;
                    case '|':
                    case '-':
                        items[i, j] = new Splitter(i, j, inputLines[i][j]);
                        break;
                }
            }
        }
        return new Map(items);
    }

    internal int Rows => items.GetLength(0);
    internal int Columns => items.GetLength(1);

    internal void EnterLight(LightSnapshot snapshot)
    {
        IItem currentItem = items[snapshot.Row, snapshot.Column];
        if (!currentItem.PreviousLightDirection.HasValue) 
        {
            LocationsLit++;
        }
        else if (currentItem.PreviousLightDirection.Value == snapshot.Direction) 
        {
            return;
        }

        IEnumerable<LightSnapshot> nextLocations = currentItem.GetNextLocations(snapshot.Direction);
        foreach (LightSnapshot location in nextLocations)
        {
            if (location.Row >= 0 && location.Column >= 0 && location.Row < Rows && location.Column < Columns)
            {
                EnterLight(location);
            }
        }
    }
}