using ForestEcosystemSimulation2.Animals;
using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2;

public class ForestEcosystemSimulation
{
    private int Width { get; set; }
    private int Height { get; set; }
    private Terrain.Terrain[][] Tiles { get; set; }
    private Animal[][] Animals { get; set; } = null;

    private int _iterations = 10;
    private static int NumAll { get; set; }
    private int NumHare { get; set; }
    private int NumDeer { get; set; }
    private int NumRacoon { get; set; }
    private int NumBear { get; set; }
    private int NumbFox { get; set; }
    private int NumWolf { get; set; }

    private Dictionary<Type, char> _animalSymbols = new Dictionary<Type, char>
    {
        { typeof(Hare), 'H' },
        { typeof(Deer), 'D' },
        { typeof(Racoon), 'R' },
        { typeof(Bear), 'B' },
        { typeof(Fox), 'F' },
        { typeof(Wolf), 'W' }
    };

    private void AddAnimals()
    {
        Animals = new Animal[Height][];
        for (int i = 0; i < Height; i++)
        {
            Animals[i] = new Animal[Width];
        }

        Random random = new Random();
        AddSpecificAnimal(random, NumHare, () => new Hare());
        AddSpecificAnimal(random, NumDeer, () => new Deer());
        AddSpecificAnimal(random, NumRacoon, () => new Racoon());
        AddSpecificAnimal(random, NumBear, () => new Bear());
        AddSpecificAnimal(random, NumbFox, () => new Fox());
        AddSpecificAnimal(random, NumWolf, () => new Wolf());
    }

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

            Animals[y][x] = createAnimal();
            Animals[y][x].X = x;
            Animals[y][x].Y = y;
        }
    }

    public static void Main()
    {
        ForestEcosystemSimulation simulation = new ForestEcosystemSimulation();
        simulation.Width = 35;
        simulation.Height = 24;
        simulation.NumHare = 2;
        simulation.NumDeer = 2;
        simulation.NumRacoon = 2;
        simulation.NumBear = 2;
        simulation.NumbFox = 2;
        simulation.NumWolf = 2;
        simulation._iterations = 50;
        simulation.Tiles = Terrain.Terrain.GenerateMap(simulation.Height, simulation.Width);
        simulation.AddAnimals();
        // Console.WriteLine($"{simulation.Animals.Length} and {simulation.Animals[0].Length}\n" +
        //                   $"{simulation.Height} and {simulation.Width}");
        simulation.PrintMap();
        //simulation.CheckMap();
        PrintControls();

        char input = Console.ReadKey().KeyChar;
        while (input != 'e')
        {
            if (input == 'r')
            {
                simulation.Tiles = Terrain.Terrain.GenerateMap(simulation.Height, simulation.Width);
                simulation.AddAnimals();
                simulation.PrintMap();
            }

            if (input == 'a')
            {
                simulation.AddAnimals();
                simulation.PrintMap();
            }

            if (input == 's')
            {
                simulation.RunSimulation(simulation._iterations);
            }

            PrintControls();
            input = Console.ReadKey().KeyChar;
        }
    }

    private void PrintMap()
    {
        Console.WriteLine();
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                int t = Tiles[i][j].Type;
                char s = ' ';
                if (Animals is not null)
                {
                    if (Animals[i][j] is not null)
                    {
                        s = _animalSymbols.TryGetValue(Animals[i][j].GetType(), out char symbol) ? symbol : ' ';
                    }
                }

                if (t == 0)
                {
                    Console.Write($"\u001b[42m {s} \u001b[0m");
                }
                else if (t == 1)
                {
                    Console.Write($"\u001b[44m {s} \u001b[0m");
                }
                else if (t == 3)
                {
                    Console.Write($"\u001b[105m {s} \u001b[0m");
                }
                else
                {
                    Console.Write($"\u001b[102m {s} \u001b[0m");
                }
            }

            Console.WriteLine();
        }
    }


    private void RunSimulation(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            if (Animals != null)
            {
                foreach (var animalY in Animals)
                {
                    foreach (var animalX in animalY)
                    {
                        animalX?.Scout(Height, Width, Tiles, Animals);
                    }
                }
                UpdateAnimalPositions();
                PrintMap();
            }
        }
    }

    public void CheckMap()
    {
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                int t = Tiles[i][j].Type;
                var c = Tiles[i][j].Contents?.TileType;
                Console.WriteLine($"{i} {j} Typ: {t} Zawartosc {c}");
            }
        }
    }

    private void UpdateAnimalPositions()
    {
        if (Animals == null) return;
        Animal[][] newAnimals = new Animal[Height][];
        for (int i = 0; i < Height; i++)
        {
            newAnimals[i] = new Animal[Width];
        }

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Animals[y][x] == null) continue;
                if (Animals[y][x].Health <= 0) continue;
                var animal = Animals[y][x];
                int newX = animal.X;
                int newY = animal.Y;
                newAnimals[newY][newX] = animal;
            }
        }

        Animals = newAnimals;
    }

    private static void PrintControls()
    {
        Console.WriteLine("""

                          r - regenerate map and animals
                          a - regenerate animals
                          s - start simulation (wip)
                          e - end

                          """);
    }
}