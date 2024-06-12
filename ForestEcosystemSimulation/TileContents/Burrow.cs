namespace ForestEcosystemSimulation.TileContents;

/// <summary>
/// Represents a burrow tile content in the forest ecosystem simulation.
/// </summary>
public class Burrow : TileContents
{
    /// <summary>
    /// Value indicating whether the burrow is currently occupied.
    /// </summary>
    public bool IsOccupied { get; private set; } = false;

    public Burrow()
    {
        TileType = 2;
    }

    /// <summary>
    /// Toggles the occupancy status of the burrow.
    /// </summary>
    public void Occupied()
    {
        IsOccupied = !IsOccupied;
    }

}