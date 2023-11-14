namespace FtlNavigator;

public class Beacon
{
    public int Id { get; }
    public int X {  get; }
    public int Y { get; }
    public bool IsExit { get; }
    public int[] AdjacentIds { get; }

    public bool IsVisited { get; set; }

    public Beacon(int id, int x, int y, bool isExit, int[] adjacentIds)
    {
        Id = id;
        X = x;
        Y = y;
        IsExit = isExit;
        AdjacentIds = adjacentIds;
    }
}