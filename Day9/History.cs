
internal class History(int[] sequence)
{
    internal static History Create(string line)
    {
        var numbers = line.Split(' ');
        return new History(numbers.Select(n => int.Parse(n)).ToArray());
    }

    internal int CalculateNextNumber()
    {
        return CalculateNextNumber(sequence);
    }

    private int CalculateNextNumber(int[] sequence)
    {
        int[] differences = new int[sequence.Length - 1];
        for (int i = 0; i < sequence.Length - 1; i++) 
        {
            differences[i] = sequence[i + 1] - sequence[i];
        }
        return differences.All(d => d == 0) ? 0 : differences[^1] + CalculateNextNumber(differences);
    }
}