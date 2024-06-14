namespace ForestEcosystemSimulation.TileContents.Food;

/// <summary>
/// Abstract base class for food sources in the forest ecosystem simulation.
/// </summary>
public abstract class Food : TileContents
{
    /// <summary>
    /// Indicates whether the food is a plant or not.
    /// </summary>
    public bool IsPlant { get; protected init; }

    /// <summary>
    /// The maximum amount of food available at this source.
    /// </summary>
    protected int MaxCount { get; set; }

    /// <summary>
    /// The current amount of food available at this source.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// The time it takes for the food source to regenerate after being depleted.
    /// </summary>
    protected int TimeToRegen { get; set; }

    /// <summary>
    /// The time that has passed since the food source was last regenerated.
    /// </summary>
    protected int TimeSinceRegen { get; set; }

    protected Food()
    {
        TileType = 0;
    }

    /// <summary>
    /// Regenerates the food source to its maximum amount.
    /// </summary>
    private void Regenerate()
    {
        Count = MaxCount;
        TimeSinceRegen = 0;
        Console.WriteLine($"{GetType().Name} regenerated.");
    }

    /// <summary>
    /// Reduces the amount of food available after it's eaten.
    /// </summary>
    /// <param name="amount">The amount of food eaten.</param>
    public void Eaten(int amount)
    {
        Count = Math.Max(0, Count - amount);
        Console.WriteLine($"{amount} of {GetType().Name} eaten.");
    }

    /// <summary>
    /// Increments the time since the food was last regenerated, and triggers <see cref="Regenerate"/> if necessary.
    /// </summary>
    public virtual void AddTime()
    {
        TimeSinceRegen += 1;
        if (TimeSinceRegen >= TimeToRegen)
        {
            Regenerate();
        }
    }
}