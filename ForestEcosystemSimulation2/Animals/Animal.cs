using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public abstract class Animal
{
    protected static readonly Random Random = new();
    protected internal int Health { get; set; }
    protected double Hunger { get; set; } = 0;
    protected double Thirst { get; set; } = 0;
    protected double Energy { get; set; } = 1;
    protected internal double Speed { get; init; }
    protected internal int Size { get; init; }
    protected int Diet { get; init; }
    public int X { get; set; }
    public int Y { get; set; }
    private List<int> Priority { get; } = new();

    protected virtual void Move(int height, int width, Terrain.Terrain[][] map)
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
        Console.WriteLine($"{GetType()} moved to [{X}, {Y}].");
    }

    protected void Move(int x, int y)
    {
        Console.WriteLine($"{GetType()} moved to [{x}, {y}].");
        X = x;
        Y = y;
    }

    protected void Eat(Food food)
    {
        Console.WriteLine($"{GetType()} at [{X}, {Y}] is eating {food.GetType()}.");
        int amount = Random.Next(0, food.Count + 1);
        Hunger = Math.Max(0, Hunger - (double)amount / 10);
        food.Eaten(amount);
    }

    protected void Drink()
    {
        Console.WriteLine($"{GetType()} at [{X}, {Y}] is drinking water.");
        Thirst = Math.Max(0, Thirst - Random.NextDouble());
    }

    protected void Rest()
    {
        Console.WriteLine($"{GetType()} at [{X}, {Y}] is resting.");
        Energy = Math.Min(Random.NextDouble() + Energy, 1);
    }

    public void Scout(int height, int width, Terrain.Terrain[][] map, Animal[][] animals)
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
                    if (animals[newY][newX] == null)
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
                    else
                    {
                        var animaltype = animals[newY][newX].Diet + 4;
                        tileInfos.Add(new TileInfo(animaltype, newX, newY));
                    }
                }
            }
        }
        MakeDecision(Priority, tileInfos, map, animals);
        UsedEnergy();

        /*Console.WriteLine(tileInfos.Count);
        foreach (var info in tileInfos)
        {
            Console.WriteLine($"{info.Content}, {info.Y}, {info.X}");
        }*/
    }

    protected virtual void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map, Animal[][] animals)
    {
        /*
         * 0 - rest
         * 1 - eat
         * 2 - drink
         * more in other classes
         */
        priorities.Clear();
        Dictionary<int, double> values = new Dictionary<int, double>
        {
            { 0, 1 - Energy },
            { 1, Hunger },
            { 2, Thirst }
        };
        priorities.AddRange(values.Keys);
        priorities.Sort((a, b) => values[b].CompareTo(values[a]));
    }

    protected void UsedEnergy()
    {
        Energy = Math.Max(0, Energy - (Random.NextDouble() * 0.19 + 0.01));
        Hunger = Math.Min(1, Hunger + (Random.NextDouble() * 0.19 + 0.01));
        Thirst = Math.Min(1, Thirst + (Random.NextDouble() * 0.19 + 0.01));
        if (Energy == 0 || Math.Abs(Hunger - 1) < 0.01 || Math.Abs(Thirst - 1) < 0.01)
        {
            Health -= 1;
        }

        if (Health == 0)
        {
            Console.WriteLine($"{GetType()} died.");
        }
    }

    protected record TileInfo(int Content, int X, int Y);
    // 0 - food, 1 - tree, 2 - burrow, 3 - water, 4 - herbivore, 5 - omnivore, 6 - carnivore
}