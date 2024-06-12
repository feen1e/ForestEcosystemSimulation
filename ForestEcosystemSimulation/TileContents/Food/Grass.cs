namespace ForestEcosystemSimulation.TileContents.Food;

/// <summary>
/// Represents a grass food source in the forest ecosystem simulation.
/// </summary>
public class Grass : Food
{
    public Grass()
    {
        IsPlant = true;
        MaxCount = new Random().Next(10, 16);
        Count = MaxCount;
        TimeToRegen = new Random().Next(60, 101);
        TimeSinceRegen = 0;
    }
}