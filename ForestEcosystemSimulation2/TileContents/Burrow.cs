namespace ForestEcosystemSimulation2.TileContents;

public class Burrow : TileContents
{
    public bool _isOccupied = false;

    public Burrow()
    {
        _tileType = 2;
    }

    public void Occupied()
    {
        _isOccupied = !_isOccupied;
    }

}