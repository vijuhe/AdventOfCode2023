internal class TurningInstructions(string turningSequence)
{
    private int sequenceLocation = 0;

    public Direction GetNextDirection()
    {
        Direction direction = turningSequence[sequenceLocation] == 'L' ? Direction.Left : Direction.Right;        
        if (sequenceLocation == turningSequence.Length - 1) 
        {
            sequenceLocation = 0;
        }
        else
        {
            sequenceLocation++;
        }        
        return direction;
    }
}