namespace ForestEcosystemSimulation.TileContents;

public class Burrow : TileContents
{
    public bool IsOccupied = false;

    public Burrow()
    {
        TileType = 2;
    }

    public void Occupied()
    {
        IsOccupied = !IsOccupied;
    }

}