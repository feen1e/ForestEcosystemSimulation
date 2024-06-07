namespace ForestEcosystemSimulation2.TileContents.Food;

public abstract class Food : TileContents
{

    protected bool IsPlant;
    protected int MaxCount;
    public int Count;
    protected int TimeToRegen;
    protected int TimeSinceRegen;

    protected Food()
    {
        TileType = 0;
    }

    public void Regenerate()
    {
        Count = MaxCount;
        TimeSinceRegen = 0;
    }

    public void Eaten(int amount)
    {
        Count = Math.Max(0, Count - amount);
    }

}