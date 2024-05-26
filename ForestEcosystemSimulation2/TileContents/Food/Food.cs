namespace ForestEcosystemSimulation.TileContents.Food;

public abstract class Food : TileContents
{

    protected bool IsPlant;
    protected int MaxCount;
    protected int Count;
    protected int TimeToRegen;
    protected int TimeSinceRegen;
    
    protected Food()
    {
        TileType = 1;       
    }

    public void Regenerate()
    {
        
    }

    public void Eaten()
    {
        
    }
    
}