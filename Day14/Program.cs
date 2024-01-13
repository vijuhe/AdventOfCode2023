string[] inputLines = await File.ReadAllLinesAsync("input.txt");
Map map = Map.Create(inputLines);
map.TiltUp();
int weight = map.CalculateWeightOnUpperEdge();
Console.WriteLine(weight);

map = Map.Create(inputLines);
int previousWeight = -1;
for  (int i = 0; i < 1000; i++)
{
    previousWeight = weight;
    map.TiltUp();
    map.TiltLeft();
    map.TiltDown();
    map.TiltRight();
    weight = map.CalculateWeightOnUpperEdge();
    //if (weight == previousWeight)
    //{
    //    Console.WriteLine(i);
    //    break;
    //}
}
Console.WriteLine(weight);
