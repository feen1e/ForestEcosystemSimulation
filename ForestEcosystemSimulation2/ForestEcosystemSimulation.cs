using ForestEcosystemSimulation.Animals;

namespace ForestEcosystemSimulation;

public class ForestEcosystemSimulation
{
    private int _width { get; set; }
    private int _height { get; set; }
    private Terrain[][] _tiles { get; set; }
    private Animal[][] _animals { get; set; } = null;

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

    public void GenerateMap()
    {
        Random random = new Random();

        _tiles = new Terrain[_height][];
        for (int i = 0; i < _height; i++)
        {
            _tiles[i] = new Terrain[_width];
            for (int j = 0; j < _width; j++)
            {
                int a = random.NextDouble() < 0.8 ? 0 : 2;
                _tiles[i][j] = new Terrain(a);
            }
        }

        // river generation
        int maxWidth = Math.Min( _width, _height ) / 5;
        maxWidth = maxWidth % 2 == 0 ? maxWidth - 1 : maxWidth;

        int row = random.Next(0, 2) == 0 ? 0 : random.Next(0, _height - 1);
        int column = row == 0 ? random.Next(0, _width - 1) : 0;

        _tiles[row][column] = new Terrain(1);

        if (row == 0)
        {
            for (int i = 0; i < _height; i++)
            {
                int move = random.Next(0, 3);
                int maxIndex = (maxWidth - 1) / 2;
                int newColumn = column;
                for (int j = 0; j < maxWidth; j++)
                {
                    int a = Math.Max(0, Math.Min(column + 1 - move + maxIndex - j, _width - 1));
                    if (j == (maxWidth - 1) / 2)
                    {
                        newColumn = a;
                    }
                    _tiles[i][a] = new Terrain(1);
                }
                column = newColumn;
            }
        } 
        else
        {
            for (int i = 0; i < _width; ++i)
            {
                int move = random.Next(0, 3);
                int maxIndex = (maxWidth - 1) / 2;
                int newRow = row;
                for (int j = 0; j < maxWidth; j++)
                {
                    int a = Math.Max(0, Math.Min(row + 1 - move + maxIndex - j, _height - 1));
                    if (j == (maxWidth - 1) / 2)
                    {
                        newRow = a;
                    }
                    _tiles[a][i] = new Terrain(1);
                }
                row = newRow;
            }
        }
    }
    
    public void AddAnimals()
    {
        _animals = new Animal[_height][];
        for (int i = 0; i < _height; i++)
        {
            _animals[i] = new Animal[_width];
        }

        Random random = new Random();
        /*int x, y;
        for (int i = 0; i < NumHare; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Hare();
        }
        for (int i = 0; i < NumDeer; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Deer();
        }
        for (int i = 0; i < NumRacoon; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Racoon();
        }
        for (int i = 0; i < NumBear; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Bear();
        }
        for (int i = 0; i < NumbFox; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Fox();
        }
        for (int i = 0; i < NumWolf; i++)
        {
            do
            {
                x = random.Next(0, _height);
                y = random.Next(0, _width);
            }
            while (_tiles[x][y].Type != 1);
            _animals[x][y] = new Wolf();
        }*/

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
            }
            while (_tiles[x][y].Type == 1);
            _animals[x][y] = createAnimal();
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
        simulation.GenerateMap();
        simulation.AddAnimals();
        simulation.PrintMap();
        PrintControls();

        char input = Console.ReadKey().KeyChar;
        while (input != 'e')
        {
            if (input == 'r')
            {
                simulation.GenerateMap();
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

    public void PrintMap()
    {
        Console.WriteLine();
        for (int i = 0; i < _height; ++i)
        {
            for (int j = 0; j < _width; ++j)
            {
                int t = _tiles[i][j].Type;
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
                    Console.Write($"\u001b[42m {s} \u001b[0m");
                } 
                else if (t == 1)
                {
                    Console.Write($"\u001b[44m {s} \u001b[0m");
                } else
                {
                    Console.Write($"\u001b[102m {s} \u001b[0m");
                }
            }
            Console.WriteLine();
        }
    }

    public static void PrintControls()
    {
        Console.WriteLine("""

            r - regenerate map and animals
            a - regenerate animals
            e - end

            """);
    }
}