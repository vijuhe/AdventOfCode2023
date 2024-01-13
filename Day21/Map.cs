using System.Collections.Generic;

internal class Map(bool[,] canStep, (int i, int j) startingPosition)
{
    private List<(int, int)> currentPossibleDestinations = [(startingPosition.i, startingPosition.j)];

    internal int CurrentPossibleDestinationsCount => currentPossibleDestinations.Count;

    internal static Map Create(string[] inputLines)
    {
        bool[,] canStep = new bool[inputLines.Length, inputLines[0].Length];
        (int i, int j) startingPosition = (-1, -1);
        for (int i = 0; i < inputLines.Length; i++)
        {
            for (int j = 0; j < inputLines[i].Length; j++)
            {
                switch (inputLines[i][j])
                {
                    case '.':
                        canStep[i, j] = true;
                        break;
                    case '#':
                        canStep[i, j] = false;
                        break;
                    case 'S':
                        canStep[i, j] = true;
                        startingPosition = (i, j);
                        break;
                }
            }
        }
        return new Map(canStep, startingPosition);
    }

    internal void TakeNextSteps()
    {
        List<(int, int)> nextPossibleDestinations = [];
        foreach ((int i, int j) position in currentPossibleDestinations)
        {
            if (position.i - 1 >= 0 && canStep[position.i - 1, position.j] && !currentPossibleDestinations.Contains((position.i - 1, position.j)))
            {
                //canStep[position.i - 1, position.j] = false;
                nextPossibleDestinations.Add((position.i - 1, position.j));
            }
            if (position.i + 1 < canStep.GetLength(0) && canStep[position.i + 1, position.j] && !currentPossibleDestinations.Contains((position.i + 1, position.j)))
            {
                //canStep[position.i + 1, position.j] = false;
                nextPossibleDestinations.Add((position.i + 1, position.j));
            }
            if (position.j - 1 >= 0 && canStep[position.i, position.j - 1] && !currentPossibleDestinations.Contains((position.i, position.j - 1)))
            {
                //canStep[position.i, position.j - 1] = false;
                nextPossibleDestinations.Add((position.i, position.j - 1));
            }
            if (position.j + 1 < canStep.GetLength(1) && canStep[position.i, position.j + 1] && !currentPossibleDestinations.Contains((position.i, position.j + 1)))
            {
                //canStep[position.i, position.j + 1] = false;
                nextPossibleDestinations.Add((position.i, position.j + 1));
            }
        }
        currentPossibleDestinations = nextPossibleDestinations;
    }
}