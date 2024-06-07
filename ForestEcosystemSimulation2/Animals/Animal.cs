using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public abstract class Animal
{
    protected static readonly Random Random = new();

    protected int Health;
    protected double Hunger = 0;
    protected double Thirst = 0;
    protected double Energy = 1;
    protected double Speed;
    protected int Size;
    protected int Diet;
    public int X { get; set; }
    public int Y { get; set; }

    public void Move(int height, int width, Terrain.Terrain[][] map)
    {
        int newX, newY;
        int count = 0;
        do
        {
            count += 1;
            newX = X + Random.Next(-1, 2);
            newY = Y + Random.Next(-1, 2);
            newX = Math.Max(0, Math.Min(newX, width - 1));
            newY = Math.Max(0, Math.Min(newY, height - 1));
        } while (map[newY][newX].Type == 1 || count < (Speed + Energy) * 10);

        X = newX;
        Y = newY;
    }

    public void Eat(Food food)
    {
        int amount = Random.Next(0, food.Count + 1);
        Hunger = Math.Max(0, Hunger - (double)amount / 10);
        food.Eaten(amount);
    }

    public void Drink(Terrain.Terrain water)
    {
        Thirst = Math.Max(0, Thirst - Random.NextDouble());
    }

    public void Rest()
    {
        Energy = Math.Min(Random.NextDouble() + Energy, 1);
    }

    public void Scout(int height, int width, Terrain.Terrain[][] map)
    {
        List<TileInfo> tileInfos = new List<TileInfo>();
        int radius = 2;
        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                int newY = Y + y;
                int newX = X + x;
                if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                {
                    var tileType = map[newY][newX].Type;
                    var tileContents = map[newY][newX].Contents;
                    if (tileContents != null)
                    {
                        tileInfos.Add(new TileInfo(tileContents.TileType, newX, newY));
                    }

                    if (tileType == 1 && tileContents == null)
                    {
                        tileInfos.Add(new TileInfo(3, newX, newY));
                    }
                }
            }
        }

        Console.WriteLine(tileInfos.Count);
        foreach (var info in tileInfos)
        {
            Console.WriteLine($"{info.Content}, {info.Y}, {info.X}");
        }
        
        // TODO dodac podejmowanie decyzji
    }


    private record TileInfo(int Content, int X, int Y);
}