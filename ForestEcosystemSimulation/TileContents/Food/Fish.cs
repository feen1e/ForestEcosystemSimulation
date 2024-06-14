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

    /// <summary>
    /// Increments the time since the food was last regenerated with a chance to increase <see cref="Food.Count"/> property, and triggers <see cref="Food.Regenerate"/> if necessary.
    /// </summary>
    public override void AddTime()
    {
        var rand = new Random();
        if (rand.NextDouble() > 0.5 && rand.Next(0, 51) > 35)
        {
            Count += rand.Next(1, 6); // fish lay eggs that hatch into more fish
        }
        base.AddTime();
        
    }
}