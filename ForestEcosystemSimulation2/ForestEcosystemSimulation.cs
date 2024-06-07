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
                x = random.Next(0, Height);
                y = random.Next(0, Width);
            } while (Tiles[x][y].Type == 1);

            Animals[x][y] = createAnimal();
            Animals[x][y].X = x;
            Animals[x][y].Y = y;
        }
    }

    public static void Main()
    {
        ForestEcosystemSimulation simulation = new ForestEcosystemSimulation();
        simulation.Width = 35;
        simulation.Height = 24;
        simulation.NumHare = 2;
        simulation.NumDeer = 0;
        simulation.NumRacoon = 0;
        simulation.NumBear = 0;
        simulation.NumbFox = 0;
        simulation.NumWolf = 0;
        simulation.Tiles = Terrain.Terrain.GenerateMap(simulation.Height, simulation.Width);
        simulation.AddAnimals();
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
                //int c = _tiles[i][j]._contents?._tileType ?? -1;
                // if (_tiles[i][j]._contents?._tileType == 0)
                // {
                //     t = 3;
                // }

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
                    /*if (c == 0)
                    {
                        Console.Write($"\u001b[101m {s} \u001b[0m");
                    }
                    else if (c == 1)
                    {
                        Console.Write($"\u001b[103m {s} \u001b[0m");
                    }
                    else if (c == 2)
                    {
                        Console.Write($"\u001b[100m {s} \u001b[0m");
                    }
                    else
                    {
                        Console.Write($"\u001b[42m {s} \u001b[0m");
                    }*/
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


    public void RunSimulation(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            foreach (var animalY in Animals)
            {
                foreach (var animalX in animalY)
                {
                    if (animalX is not null)
                    {
                        animalX.Scout(Height, Width, Tiles);
                    }
                    
                }
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


    private static void PrintControls()
    {
        Console.WriteLine("""

                          r - regenerate map and animals
                          a - regenerate animals
                          e - end

                          """);
    }
}