using ForestEcosystemSimulation2.Animals;
using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2;

public class ForestEcosystemSimulation
{
    private int _width { get; set; }
    private int _height { get; set; }
    private Terrain.Terrain[][] _tiles { get; set; }
    private Animal[][] _animals { get; set; } = null;

    private int _iterations = 100;

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
        _animals = new Animal[_height][];
        for (int i = 0; i < _height; i++)
        {
            _animals[i] = new Animal[_width];
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
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            } while (_tiles[x][y]._type == 1);

            _animals[x][y] = createAnimal();
            _animals[x][y]._x = x;
            _animals[x][y]._y = y;
        }
    }

    public static void Main()
    {
        ForestEcosystemSimulation simulation = new ForestEcosystemSimulation();
        simulation._width = 35;
        simulation._height = 24;
        simulation.NumHare = 2;
        simulation.NumDeer = 2;
        simulation.NumRacoon = 2;
        simulation.NumBear = 2;
        simulation.NumbFox = 2;
        simulation.NumWolf = 2;
        simulation._tiles = Terrain.Terrain.GenerateMap(simulation._height, simulation._width);
        simulation.AddAnimals();
        simulation.PrintMap();
        PrintControls();

        char input = Console.ReadKey().KeyChar;
        while (input != 'e')
        {
            if (input == 'r')
            {
                simulation._tiles = Terrain.Terrain.GenerateMap(simulation._height, simulation._width);
                simulation.AddAnimals();
                simulation.PrintMap();
            }

            if (input == 'a')
            {
                simulation.AddAnimals();
                simulation.PrintMap();
            }

            PrintControls();
            input = Console.ReadKey().KeyChar;
        }
    }

    private void PrintMap()
    {
        Console.WriteLine();
        for (int i = 0; i < _height; ++i)
        {
            for (int j = 0; j < _width; ++j)
            {
                int t = _tiles[i][j]._type;
                //int c = _tiles[i][j]._contents?._tileType ?? -1;
                // if (_tiles[i][j]._contents?._tileType == 0)
                // {
                //     t = 3;
                // }

                char s = ' ';
                if (_animals is not null)
                {
                    if (_animals[i][j] is not null)
                    {
                        s = _animalSymbols.TryGetValue(_animals[i][j].GetType(), out char symbol) ? symbol : ' ';
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