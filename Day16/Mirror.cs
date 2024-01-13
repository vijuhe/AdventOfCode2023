internal class Mirror(int row, int column, char mirrorItem) : IItem
{
    public Direction? PreviousLightDirection { get; private set; }

    IEnumerable<LightSnapshot> IItem.GetNextLocations(Direction direction)
    {
        PreviousLightDirection = direction;
        return direction switch
        {
            Direction.Up => mirrorItem == '/' ? [new(row, column + 1, Direction.Right)] : [new(row, column - 1, Direction.Left)],
            Direction.Down => mirrorItem == '/' ? [new(row, column - 1, Direction.Left)] : [new(row, column + 1, Direction.Right)],
            Direction.Left => mirrorItem == '/' ? [new(row + 1, column, Direction.Down)] : [new(row - 1, column, Direction.Up)],
            Direction.Right => mirrorItem == '/' ? [new(row - 1, column, Direction.Up)] : [new(row + 1, column, Direction.Down)]
        };
    }
}