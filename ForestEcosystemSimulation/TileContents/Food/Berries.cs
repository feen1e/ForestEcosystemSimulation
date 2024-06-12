namespace ForestEcosystemSimulation.TileContents.Food;

/// <summary>
/// Represents a berries food source in the forest ecosystem simulation.
/// </summary>
public class Berries : Food
{
    public Berries()
    {
        IsPlant = true;
        MaxCount = new Random().Next(5, 11);
        Count = MaxCount;
        TimeToRegen = new Random().Next(30, 61);
        TimeSinceRegen = 0;
    }
}