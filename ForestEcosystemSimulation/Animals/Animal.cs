using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents the base class for all animals in the forest ecosystem simulation.
/// </summary>
public abstract class Animal
{
    /// <summary>
    /// Random number generator shared by all animals.
    /// </summary>
    protected static readonly Random Random = new();
    
    /// <summary>
    /// The maximum health of the animal.
    /// </summary>
    protected int MaxHealth { get; init; }
    
    /// <summary>
    /// The current health of the animal.
    /// </summary>
    protected internal int Health { get; set; }
    
    /// <summary>
    /// The hunger level of the animal (0.0 to 1.0).
    /// </summary>
    protected double Hunger { get; set; } = 0;
    
    /// <summary>
    /// The thirst level of the animal (0.0 to 1.0).
    /// </summary>
    protected double Thirst { get; private set; } = 0;
    
    /// <summary>
    /// The energy level of the animal (0.0 to 1.0).
    /// </summary>
    protected double Energy { get; private set; } = 1;
    
    /// <summary>
    /// The speed of the animal, affecting movement distance.
    /// </summary>
    protected internal double Speed { get; protected init; }
    
    /// <summary>
    /// The size of the animal, influencing interactions with other animals.
    /// </summary>
    protected internal int Size { get; protected init; }
    
    /// <summary>
    /// The diet type of the animal (0: Herbivore, 1: Omnivore, 2: Carnivore).
    /// </summary>
    protected int Diet { get; init; }
    
    /// <summary>
    /// The X coordinate of the animal on the map.
    /// </summary>
    public int X { get; set; }
    
    /// <summary>
    /// The Y coordinate of the animal on the map.
    /// </summary>
    public int Y { get; set; }
    
    /// <summary>
    /// List of action priorities for the animal's decision-making.
    /// </summary>
    private List<int> Priority { get; } = new();

    /// <summary>
    /// Moves the animal randomly to a valid location on the map, avoiding river tiles (Type 1).
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The 2D array representing the terrain map.</param>
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
        } while (map[newY][newX].Type == 1 && count < (Speed + Energy) * 10);

        X = newX;
        Y = newY;
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} moved to [{X}, {Y}].");
    }

    /// <summary>
    /// Moves the animal to the specified coordinates.
    /// </summary>
    /// <param name="x">The new X coordinate.</param>
    /// <param name="y">The new Y coordinate.</param>
    protected void Move(int x, int y)
    {
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} moved to [{x}, {y}].");
        X = x;
        Y = y;
    }

    /// <summary>
    /// Simulates the animal eating food.
    /// </summary>
    /// <param name="food">The food to eat.</param>
    protected void Eat(Food food)
    {
        Console.WriteLine(
            $"{GetType().ToString().Split('.').Last()} at [{X}, {Y}] is eating {food.GetType().ToString().Split('.').Last()}.");
        int amount = Random.Next(0, food.Count + 1);
        Hunger = Math.Max(0, Hunger - (double)amount / 10);
        food.Eaten(amount);
    }

    /// <summary>
    /// Simulates the animal drinking water.
    /// </summary>
    protected void Drink()
    {
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} at [{X}, {Y}] is drinking water.");
        Thirst = Math.Max(0, Thirst - Random.NextDouble());
    }

    /// <summary>
    /// Simulates the animal resting, replenishing its energy.
    /// </summary>
    protected void Rest()
    {
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} at [{X}, {Y}] is resting.");
        Energy = Math.Min(Random.NextDouble() + Energy, 1);
    }

    /// <summary>
    /// Allows the animal to scout its surroundings and make a decision based on the information gathered.
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The 2D array representing the terrain map.</param>
    /// <param name="animals">The list of all animals in the simulation.</param>
    public void Scout(int height, int width, Terrain.Terrain[][] map, List<Animal> animals)
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
                    if (!animals.Any(animal => animal.X == newX && animal.Y == newY))
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
                        var animal = animals.FirstOrDefault(animal => animal.X == newX && animal.Y == newY);
                        if (animal != null)
                        {
                            var animaltype = animal.Diet + 4;
                            tileInfos.Add(new TileInfo(animaltype, newX, newY));
                        }
                    }
                }
            }
        }
        MakeDecision(Priority, tileInfos, map, animals);
        UsedEnergy();
    }

    /// <summary>
    /// Determines the animal's next action based on its priorities and the surrounding environment.
    /// </summary>
    /// <param name="priorities">List of actions sorted by priority.</param>
    /// <param name="tileInfos">Information about surrounding tiles.</param>
    /// <param name="map">The simulation map.</param>
    /// <param name="animals">List of animals in the simulation.</param>
    protected virtual void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        List<Animal> animals)
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

    /// <summary>
    /// Updates the animal's energy, hunger, and thirst after performing an action.
    /// </summary>
    protected void UsedEnergy()
    {
        Energy = Math.Max(0, Energy - (Random.NextDouble() * 0.15 + 0.01));
        Hunger = Math.Min(1, Hunger + (Random.NextDouble() * 0.15 + 0.01));
        Thirst = Math.Min(1, Thirst + (Random.NextDouble() * 0.15 + 0.01));
        if (Energy == 0 || Math.Abs(Hunger - 1) < 0.01 || Math.Abs(Thirst - 1) < 0.01)
        {
            Health -= 1;
        }
        else
        {
            Health = Math.Min(MaxHealth, Health + 1);
        }

        if (Health <= 0)
        {
            Console.WriteLine($"{GetType().ToString().Split('.').Last()} died.");
        }
    }
    
    /// <summary>
    /// A record representing information about a tile in the animal's vicinity.
    /// </summary>
    /// <param name="Content">The content type of the tile (0: Food, 1: Tree, 2: Burrow, 3: Water, 4: Herbivore, 5: Omnivore, 6: Carnivore).</param>
    /// <param name="X">The X coordinate of the tile.</param>
    /// <param name="Y">The Y coordinate of the tile.</param>
    protected record TileInfo(int Content, int X, int Y);
}