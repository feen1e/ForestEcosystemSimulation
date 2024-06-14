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

    /// <summary>
    /// Increments the time since the food was last regenerated with a chance to increase <see cref="Food.MaxCount"/>, and triggers <see cref="Food.Regenerate"/> if necessary.
    /// </summary>
    public override void AddTime()
    {
        var rand = new Random();
        if (rand.NextDouble() < 0.5 && rand.Next(0, 51) < 15) 
        {
            MaxCount += rand.Next(1, 6); // berry bush grows larger so it produces more food
        }
        base.AddTime();
    }
}