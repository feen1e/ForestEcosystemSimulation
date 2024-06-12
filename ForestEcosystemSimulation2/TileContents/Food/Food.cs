namespace ForestEcosystemSimulation2.TileContents.Food;

public abstract class Food : TileContents
{
    public bool IsPlant;
    protected int MaxCount;
    public int Count;
    protected int TimeToRegen;
    protected int TimeSinceRegen;

    protected Food()
    {
        TileType = 0;
    }

    private void Regenerate()
    {
        Count = MaxCount;
        TimeSinceRegen = 0;
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} regenerated.");
    }

    public void Eaten(int amount)
    {
        Count = Math.Max(0, Count - amount);
        Console.WriteLine($"{amount} of {GetType().ToString().Split('.').Last()} eaten.");
    }

    public void AddTime()
    {
        TimeSinceRegen += 1;
        if (TimeSinceRegen >= TimeToRegen)
        {
            Regenerate();
        }
    }
}