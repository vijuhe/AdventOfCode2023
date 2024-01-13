
internal class Map
{
    private readonly char[,] items;
    private int currentVerticalReflectionIndex = 0;
    private int currentHorizontalReflectionIndex = 0;

    public Map(string[] mapLines)
    {
        items = new char[mapLines.Length, mapLines.First().Length];
        for (int i = 0; i < mapLines.Length; i++) 
        {
            for (int j = 0; j < mapLines[i].Length; j++)
            {
                items[i, j] = mapLines[i][j];
            }
        }
    }

    internal int? GetNextHorizontalReflectionIndex()
    {
        for (int i = currentHorizontalReflectionIndex; i < items.GetLength(0); i++)
        {
            if (ContainsOnlySameRecedingRows(i, i + 1))
            {
                currentHorizontalReflectionIndex = i + 1;
                return currentHorizontalReflectionIndex;
            }
        }
        return null;
    }

    internal int? GetNextVerticalReflectionIndex()
    {
        for (int i = currentVerticalReflectionIndex; i < items.GetLength(1); i++)
        {
            if (ContainsOnlySameRecedingColumns(i, i + 1))
            {
                currentVerticalReflectionIndex = i + 1;
                return currentVerticalReflectionIndex;
            }
        }
        return null;
    }

    private bool ContainsOnlySameRecedingRows(int higherRowIndex, int lowerRowIndex)
    {
        if (higherRowIndex < 0 || lowerRowIndex >= items.GetLength(0))
        {
            return lowerRowIndex - higherRowIndex > 1;
        }
        for (int i = 0; i < items.GetLength(1); i++)
        {
            if (items[higherRowIndex, i] != items[lowerRowIndex, i])
            {
                return false;
            }
        }
        return ContainsOnlySameRecedingRows(higherRowIndex - 1, lowerRowIndex + 1);
    }

    private bool ContainsOnlySameRecedingColumns(int leftColumnIndex, int rightColumnIndex)
    {
        if (leftColumnIndex < 0 || rightColumnIndex >= items.GetLength(1))
        {
            return rightColumnIndex - leftColumnIndex > 1;
        }
        for (int i = 0; i < items.GetLength(0); i++)
        {
            if (items[i, leftColumnIndex] != items[i, rightColumnIndex])
            {
                return false;
            }
        }
        return ContainsOnlySameRecedingColumns(leftColumnIndex - 1, rightColumnIndex + 1);
    }
}