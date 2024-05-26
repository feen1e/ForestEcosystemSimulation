using ForestEcosystemSimulation.TileContents;
using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation;

public class Terrain
{
    public readonly int Type;
    public TileContents.TileContents? Contents;

    public Terrain(int type)
    {
        Type = type;
        double d = new Random().NextDouble();
        if (Type == 0)
        {
            // Forest
            TileContents.TileContents[] possibleContents = 
                [new Tree(), new Berries(), new Burrow()];
            Contents = d switch
            {
                < 0.5 => null,
                < 0.8 => possibleContents[0],
                < 0.9 => possibleContents[1],
                _ => possibleContents[2]
            };
        } else if (Type == 1)
        {
            // River
            TileContents.TileContents[] possibleContents = 
                [new Fish()];
            Contents = d switch
            {
                < 0.75 => null,
                _ => possibleContents[0]
            };
        }
        else if (Type == 2)
        {
            // Meadow
            TileContents.TileContents[] possibleContents = 
                [new Grass(), new Burrow()];
            Contents = d switch
            {
                < 0.70 => null,
                < 0.90 => possibleContents[0],
                _ => possibleContents[1]
            };
        }
        else
        {
            Console.Error.WriteLine($"Invalid terrain type: {Type}");
        }
    }
}