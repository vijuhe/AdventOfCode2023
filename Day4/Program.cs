double points = 0;
Dictionary<int, int> cardsByNumber = [];
int cardCount = 0;

await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    var card = Card.Create(line);
    AddCard(card.SequenceNumber);
    int winningNumberCount = card.GetWinningNumberCount();
    if (winningNumberCount > 0)
    {
        AddCards(card.SequenceNumber, winningNumberCount);
        double score = Math.Pow(2, winningNumberCount - 1);
        points += score;
    }
}

Console.WriteLine(points);
Console.WriteLine(cardCount);

void AddCards(int sequenceNumber, int winningNumberCount)
{
    for (int i = 1; i <= winningNumberCount; i++)
    {
        AddCard(sequenceNumber + i);
    }
}

void AddCard(int sequenceNumber)
{
    if (cardsByNumber.TryGetValue(sequenceNumber, out int value))
    {
        cardsByNumber[sequenceNumber] = ++value;
    }
    else
    {
        cardsByNumber[sequenceNumber] = 1;
    }
}