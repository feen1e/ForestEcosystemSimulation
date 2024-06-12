namespace ForestEcosystemSimulation.TileContents;

/// <summary>
/// Abstract base class representing the contents of a tile in the forest ecosystem simulation.
/// </summary>
public abstract class TileContents
{
    public int TileType { get; protected init; }
}