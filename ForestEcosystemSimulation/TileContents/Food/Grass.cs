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

    /// <summary>
    /// Increments the time since the food was last regenerated with a chance to decrease <see cref="Food.TimeToRegen"/>, and triggers <see cref="Food.Regenerate"/> if necessary.
    /// </summary>
    public override void AddTime()
    {
        var rand = new Random();
        if (rand.NextDouble() > 0.3 && rand.Next(0, 51) < 10)
        {
            TimeToRegen = Math.Max(1, TimeToRegen - rand.Next(1, 6)); // grass grows and its roots establish deeper, so it regenerates faster
        }
        base.AddTime();
    }
}