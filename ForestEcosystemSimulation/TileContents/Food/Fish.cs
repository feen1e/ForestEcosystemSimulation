namespace ForestEcosystemSimulation.TileContents.Food;

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