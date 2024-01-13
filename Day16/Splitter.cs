internal class Splitter(int row, int column, char splitterItem) : IItem
{
    public Direction? PreviousLightDirection { get; private set; }

    public IEnumerable<LightSnapshot> GetNextLocations(Direction direction)
    {
        PreviousLightDirection = direction;
        return direction switch
        {
            Direction.Up => splitterItem == '|' ? [new(row - 1, column, Direction.Up)] : [new(row, column + 1, Direction.Right), new(row, column - 1, Direction.Left)],
            Direction.Down => splitterItem == '|' ? [new(row + 1, column, Direction.Down)] : [new(row, column + 1, Direction.Right), new(row, column - 1, Direction.Left)],
            Direction.Left => splitterItem == '|' ? [new(row - 1, column, Direction.Up), new(row + 1, column, Direction.Down)] : [new(row, column - 1, Direction.Left)],
            Direction.Right => splitterItem == '|' ? [new(row - 1, column, Direction.Up), new(row + 1, column, Direction.Down)] : [new(row, column + 1, Direction.Right)]
        };
    }
}