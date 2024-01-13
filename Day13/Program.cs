var maps = new Maps();
await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    maps.Parse(line);
}
Console.WriteLine(maps.GetTotalReflectionsSum());