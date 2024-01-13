internal interface IItem
{
    IEnumerable<LightSnapshot> GetNextLocations(Direction direction);
    Direction? PreviousLightDirection { get; }
}
