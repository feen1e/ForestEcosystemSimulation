using ForestEcosystemSimulation2.TileContents;
using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Terrain;

public class Terrain
{
    public readonly int _type;
    public TileContents.TileContents? _contents;

    public Terrain(int type)
    {
        _type = type;
        double d = new Random().NextDouble();
        if (_type == 0)
        {
            // Forest
            TileContents.TileContents[] possibleContents =
                [new Tree(), new Berries(), new Burrow()];
            _contents = d switch
            {
                < 0.5 => null,
                < 0.8 => possibleContents[0],
                < 0.9 => possibleContents[1],
                _ => possibleContents[2]
            };
        }
        else if (_type == 1)
        {
            // River
            TileContents.TileContents[] possibleContents =
                [new Fish()];
            _contents = d switch
            {
                < 0.75 => null,
                _ => possibleContents[0]
            };
        }
        else if (_type == 2)
        {
            // Meadow
            TileContents.TileContents[] possibleContents =
                [new Grass(), new Burrow()];
            _contents = d switch
            {
                < 0.70 => null,
                < 0.90 => possibleContents[0],
                _ => possibleContents[1]
            };
        }
        else
        {
            Console.Error.WriteLine($"Invalid terrain type: {_type}");
        }
    }

    public static Terrain[][] GenerateMap(int height, int width)
    {
        Random random = new Random();

        Terrain[][] map = new Terrain[height][];
        for (int i = 0; i < height; i++)
        {
            map[i] = new Terrain[width];
            for (int j = 0; j < width; j++)
            {
                int a = random.NextDouble() < 0.8 ? 0 : 2;
                map[i][j] = new Terrain(a);
            }
        }

        // river generation
        int maxWidth = Math.Min(width, height) / 5;
        maxWidth = maxWidth % 2 == 0 ? maxWidth - 1 : maxWidth;

        int row = random.Next(0, 2) == 0 ? 0 : random.Next(0, height - 1);
        int column = row == 0 ? random.Next(0, width - 1) : 0;

        map[row][column] = new Terrain(1);

        if (row == 0)
        {
            for (int i = 0; i < height; i++)
            {
                int move = random.Next(0, 3);
                int maxIndex = (maxWidth - 1) / 2;
                int newColumn = column;
                for (int j = 0; j < maxWidth; j++)
                {
                    int a = Math.Max(0, Math.Min(column + 1 - move + maxIndex - j, width - 1));
                    if (j == (maxWidth - 1) / 2)
                    {
                        newColumn = a;
                    }

                    map[i][a] = new Terrain(1);
                }

                column = newColumn;
            }
        }
        else
        {
            for (int i = 0; i < width; ++i)
            {
                int move = random.Next(0, 3);
                int maxIndex = (maxWidth - 1) / 2;
                int newRow = row;
                for (int j = 0; j < maxWidth; j++)
                {
                    int a = Math.Max(0, Math.Min(row + 1 - move + maxIndex - j, height - 1));
                    if (j == (maxWidth - 1) / 2)
                    {
                        newRow = a;
                    }

                    map[a][i] = new Terrain(1);
                }

                row = newRow;
            }
        }

        return map;
    }
}