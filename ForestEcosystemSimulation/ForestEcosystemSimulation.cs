using ForestEcosystemSimulation.Animals;
using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation;

/// <summary>
/// Simulates a forest ecosystem with various animal species.
/// </summary>
public class ForestEcosystemSimulation
{
    /// <summary>
    /// Width of the simulation map.
    /// </summary>
    private int Width { get; set; }
    
    /// <summary>
    /// Height of the simulation map.
    /// </summary>
    private int Height { get; set; }
    
    /// <summary>
    /// 2D array representing the terrain of the simulation map.
    /// </summary>
    private Terrain.Terrain[][] Tiles { get; set; }
    
    /// <summary>
    /// List of animals currently in the simulation.
    /// </summary>
    private List<Animal> Animals { get; set; } = [];

    /// <summary>
    /// Number of iterations to run the simulation for.
    /// </summary>
    private int _iterations = 10;

    /// <summary>
    /// Number of hares to be added to the simulation.
    /// </summary>
    private int NumHare { get; set; }
    
    /// <summary>
    /// Number of deer to be added to the simulation.
    /// </summary>
    private int NumDeer { get; set; }
    
    /// <summary>
    /// Number of racoons to be added to the simulation.
    /// </summary>
    private int NumRacoon { get; set; }
    
    /// <summary>
    /// Number of Bears to be added to the simulation.
    /// </summary>
    private int NumBear { get; set; }
    
    /// <summary>
    /// Number of foxes to be added to the simulation.
    /// </summary>
    private int NumFox { get; set; }
    
    /// <summary>
    /// Number of wolfs to be added to the simulation.
    /// </summary>
    private int NumWolf { get; set; }

    /// <summary>
    /// Dictionary mapping animal types to their display symbols.
    /// </summary>
    private readonly Dictionary<Type, char> _animalSymbols = new Dictionary<Type, char>
    {
        { typeof(Hare), 'H' },
        { typeof(Deer), 'D' },
        { typeof(Racoon), 'R' },
        { typeof(Bear), 'B' },
        { typeof(Fox), 'F' },
        { typeof(Wolf), 'W' }
    };


    /// <summary>
    /// Adds animals to the simulation based on the configured numbers for each type.
    /// </summary>
    private void AddAnimals()
    {
        Animals.Clear();
        Random random = new Random();
        AddSpecificAnimal(random, NumHare, () => new Hare());
        AddSpecificAnimal(random, NumDeer, () => new Deer());
        AddSpecificAnimal(random, NumRacoon, () => new Racoon());
        AddSpecificAnimal(random, NumBear, () => new Bear());
        AddSpecificAnimal(random, NumFox, () => new Fox());
        AddSpecificAnimal(random, NumWolf, () => new Wolf());
        UpdateAnimalPositions();
    }

    /// <summary>
    /// Adds a specified number of animals of a specific type to the simulation.
    /// </summary>
    /// <param name="random">Random number generator for positioning animals.</param>
    /// <param name="numAnimals">The number of animals to add.</param>
    /// <param name="createAnimal">A function that creates an instance of the animal type.</param>
    private void AddSpecificAnimal(Random random, int numAnimals, Func<Animal> createAnimal)
    {
        int x, y;
        for (int i = 0; i < numAnimals; i++)
        {
            do
            {
                y = random.Next(0, Height);
                x = random.Next(0, Width);
            } while (Tiles[y][x].Type == 1);

            Animal createdAnimal = createAnimal();
            createdAnimal.X = x;
            createdAnimal.Y = y;
            Animals.Add(createdAnimal);
        }
    }

    public static void Main()
    {
        ForestEcosystemSimulation simulation = new ForestEcosystemSimulation();
        simulation.Width = 50;
        simulation.Height = 100;
        simulation.NumHare = 2;
        simulation.NumDeer = 2;
        simulation.NumRacoon = 2;
        simulation.NumBear = 2;
        simulation.NumFox = 2;
        simulation.NumWolf = 2;
        simulation._iterations = 50;
        simulation.Tiles = Terrain.Terrain.GenerateMap(simulation.Height, simulation.Width);
        simulation.AddAnimals();
        
        /*foreach (var animal in simulation.Animals)
        {
            Console.WriteLine($"Animal X: {animal.X}, Y: {animal.Y}");
        }*/

        simulation.PrintMap();
        //simulation.CheckMap();
        PrintControls();

        char input = Console.ReadKey().KeyChar;
        while (input != 'e')
        {
            switch (input)
            {
                case 'r':
                    simulation.Tiles = Terrain.Terrain.GenerateMap(simulation.Height, simulation.Width);
                    simulation.AddAnimals();
                    simulation.PrintMap();
                    break;
                case 'a':
                    simulation.AddAnimals();
                    simulation.PrintMap();
                    break;
                case 's':
                    simulation.RunSimulation(simulation._iterations);
                    break;
                case 'c':
                    simulation.CheckMap();
                    break;
            }

            PrintControls();
            input = Console.ReadKey().KeyChar;
        }
    }

    /// <summary>
    /// Prints a visual representation of the simulation map with animals.
    /// </summary>
    private void PrintMap()
    {
        Console.WriteLine();
        int index = 0;
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                int t = Tiles[i][j].Type; // terrain type
                char s = ' '; // animal symbol

                if (index < Animals.Count)
                {
                    if (Animals[index].Y == i && Animals[index].X == j)
                    {
                        s = _animalSymbols.GetValueOrDefault(Animals[index].GetType(), ' ');
                        index += 1;
                    }
                }

                switch (t)
                {
                    // forest
                    case 0:
                        Console.Write($"\u001b[42m {s} \u001b[0m");
                        break;
                    // river
                    case 1:
                        Console.Write($"\u001b[44m {s} \u001b[0m");
                        break;
                    // meadow
                    case 2:
                        Console.Write($"\u001b[102m {s} \u001b[0m");
                        break;
                }
            }

            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// Runs the forest ecosystem simulation for the specified number of iterations.
    /// </summary>
    /// <param name="iterations">Number of iterations to run.</param>
    private void RunSimulation(int iterations)
    {
        if (Animals.Count == 0)
        {
            Console.WriteLine("There are no animals on the map.");
            return;
        }

        for (int i = 0; i < iterations; i++)
        {
            if (Animals.Count <= 0)
            {
                Console.WriteLine("All animals died. Simulation ended.");
                return;
            }

            foreach (var animal in Animals)
            {
                animal.Scout(Height, Width, Tiles, Animals);
            }

            IncreaseTimeSinceRegen(); // increases TimeSinceRegen of Food objects
            UpdateAnimalPositions(); // updates the positions of animals
            PrintMap(); // prints the map
        }
    }

    /// <summary>
    /// Prints information about each tile in the map, including terrain type and contents.
    /// </summary>
    private void CheckMap()
    {
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                int t = Tiles[i][j].Type;
                var c = Tiles[i][j].Contents?.TileType;
                Console.WriteLine($"Tile: {i} {j} Type: {t} Content: {c}");
            }
        }
    }

    /// <summary>
    /// Updates the positions of animals in the simulation list.
    /// </summary>
    private void UpdateAnimalPositions()
    {
        if (Animals.Count == 0) return;
        // sorts the list of animals by Y and X in ascending order
        List<Animal> sortedList = Animals 
            .OrderBy(animal => animal.Y)
            .ThenBy(animal => animal.X)
            .ToList();
        // selects animals that have died and removes them from the list
        List<Animal> deadAnimals = sortedList.Where(animal => animal.Health <= 0).ToList();
        foreach (var deadAnimal in deadAnimals)
        {
            sortedList.Remove(deadAnimal);
        }

        Animals = sortedList;
    }

    /// <summary>
    /// Increments the time since food sources have regenerated.
    /// </summary>
    private void IncreaseTimeSinceRegen()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Tiles[y][x].Contents is Food food)
                {
                    food.AddTime();
                }
            }
        }
    }

    private static void PrintControls()
    {
        Console.WriteLine("""

                          r - regenerate map and animals
                          a - regenerate animals
                          c - check contents of the map
                          s - start simulation (wip)
                          e - end

                          """);
    }
}