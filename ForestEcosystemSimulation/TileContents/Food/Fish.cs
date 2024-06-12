namespace ForestEcosystemSimulation.TileContents.Food;

/// <summary>
/// Represents a fish food source in the forest ecosystem simulation.
/// </summary>
public class Fish : Food
{
    public Fish()
    {
        IsPlant = false;
        MaxCount = new Random().Next(10, 21);
        Count = MaxCount;
        TimeToRegen = new Random().Next(100, 201);
        TimeSinceRegen = 0;
    }
}