internal class Map(RockType[,] rocks)
{
    internal static Map Create(string[] inputLines)
    {
        RockType[,] rocks = new RockType[inputLines.Length, inputLines[0].Length];
        for (int i = 0; i < inputLines.Length; i++) 
        {
            for (int j = 0; j < inputLines[i].Length; j++) 
            {
                switch (inputLines[i][j])
                {
                    case '.':
                        rocks[i, j] = RockType.Empty; 
                        break;
                    case '#':
                        rocks[i, j] = RockType.Cube; 
                        break;
                    case 'O':
                        rocks[i, j] = RockType.Round; 
                        break;
                }
            }
        }
        return new Map(rocks);
    }

    internal int CalculateWeightOnUpperEdge()
    {
        int weight = 0;
        for (int i = 0; i < rocks.GetLength(0); i++) 
        {
            for (int j = 0; j < rocks.GetLength(1); j++)
            {
                if (rocks[i, j] == RockType.Round)
                {
                    weight += rocks.GetLength(0) - i;
                }
            }
        }
        return weight;
    }

    internal void TiltDown()
    {
        for (int row = rocks.GetLength(0) - 1; row >= 0; row--)
        {
            for (int column = 0; column < rocks.GetLength(1); column++)
            {
                if (rocks[row, column] == RockType.Round)
                {
                    MoveRockDown(row, column);
                }
            }
        }
    }

    internal void TiltLeft()
    {
        for (int column = 0; column < rocks.GetLength(1); column++)
        {
            for (int row = 0; row < rocks.GetLength(0); row++)
            {
                if (rocks[row, column] == RockType.Round)
                {
                    MoveRockLeft(row, column);
                }
            }
        }
    }

    internal void TiltRight()
    {
        for (int column = rocks.GetLength(1) - 1; column >= 0; column--)
        {
            for (int row = 0; row < rocks.GetLength(0); row++)
            {
                if (rocks[row, column] == RockType.Round)
                {
                    MoveRockRight(row, column);
                }
            }
        }
    }

    internal void TiltUp()
    {
        for (int row = 0; row < rocks.GetLength(0); row++)
        {
            for (int column = 0; column < rocks.GetLength(1); column++)
            {
                if (rocks[row, column] == RockType.Round)
                {
                    MoveRockUp(row, column);
                }
            }
        }
    }

    private void MoveRockDown(int rowIndex, int columnIndex)
    {
        if (rowIndex < rocks.GetLength(0) - 1 && rocks[rowIndex + 1, columnIndex] == RockType.Empty)
        {
            rocks[rowIndex, columnIndex] = RockType.Empty;
            rocks[rowIndex + 1, columnIndex] = RockType.Round;
            MoveRockDown(rowIndex + 1, columnIndex);
        }
    }

    private void MoveRockLeft(int rowIndex, int columnIndex)
    {
        if (columnIndex > 0 && rocks[rowIndex, columnIndex - 1] == RockType.Empty)
        {
            rocks[rowIndex, columnIndex] = RockType.Empty;
            rocks[rowIndex, columnIndex - 1] = RockType.Round;
            MoveRockLeft(rowIndex, columnIndex - 1);
        }
    }

    private void MoveRockRight(int rowIndex, int columnIndex)
    {
        if (columnIndex < rocks.GetLength(1) - 1 && rocks[rowIndex, columnIndex + 1] == RockType.Empty)
        {
            rocks[rowIndex, columnIndex] = RockType.Empty;
            rocks[rowIndex, columnIndex + 1] = RockType.Round;
            MoveRockRight(rowIndex, columnIndex + 1);
        }
    }

    private void MoveRockUp(int rowIndex, int columnIndex)
    {
        if (rowIndex > 0 && rocks[rowIndex - 1, columnIndex] == RockType.Empty)
        {
            rocks[rowIndex, columnIndex] = RockType.Empty;
            rocks[rowIndex - 1, columnIndex] = RockType.Round;
            MoveRockUp(rowIndex - 1, columnIndex);
        }
    }
}