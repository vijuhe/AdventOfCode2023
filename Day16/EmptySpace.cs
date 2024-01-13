internal class EmptySpace(int row, int column) : IItem
{
    public Direction? PreviousLightDirection { get; private set; }

    IEnumerable<LightSnapshot> IItem.GetNextLocations(Direction direction)
    {
        PreviousLightDirection = direction;
        return direction switch
        {
            Direction.Up => [new(row - 1, column, direction)],
            Direction.Down => [new(row + 1, column, direction)],
            Direction.Left => [new(row, column - 1, direction)],
            Direction.Right => [new(row, column + 1, direction)]
        };
    }
}