namespace ForestEcosystemSimulation2.TileContents.Food;

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
}