using ForestEcosystemSimulation.TileContents;
using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Terrain;

/// <summary>
/// Represents a single tile in the forest ecosystem simulation.
/// </summary>
public class Terrain
{
    /// <summary>
    /// Type of the terrain (0: Forest, 1: River, 2: Meadow).
    /// </summary>
    public int Type { get; }
    
    /// <summary>
    /// Contents of the tile (Tree, Berries, Fish, Grass, Burrow, or null if empty).
    /// </summary>
    public readonly TileContents.TileContents? Contents;

    /// <summary>
    /// Initializes a new instance of the <see cref="Terrain"/> class with the specified type.
    /// Randomly assigns contents based on the terrain type.
    /// </summary>
    /// <param name="type">The type of terrain (0: Forest, 1: River, 2: Meadow).</param>
    private Terrain(int type)
    {
        Type = type;
        double d = new Random().NextDouble();
        switch (Type)
        {
            case 0:
            {
                // Forest
                TileContents.TileContents[] possibleContents =
                    [new Tree(), new Berries(), new Burrow()];
                Contents = d switch
                {
                    < 0.4 => null,
                    < 0.5 => possibleContents[0],
                    < 0.9 => possibleContents[1],
                    _ => possibleContents[2]
                };
                break;
            }
            case 1:
            {
                // River
                TileContents.TileContents[] possibleContents =
                    [new Fish()];
                Contents = d switch
                {
                    < 0.4 => null,
                    _ => possibleContents[0]
                };
                break;
            }
            case 2:
            {
                // Meadow
                TileContents.TileContents[] possibleContents =
                    [new Grass(), new Burrow()];
                Contents = d switch
                {
                    < 0.3 => null,
                    < 0.8 => possibleContents[0],
                    _ => possibleContents[1]
                };
                break;
            }
            default:
                Console.Error.WriteLine($"Invalid terrain type: {Type}");
                break;
        }
    }

    /// <summary>
    /// Generates a random terrain map with the specified height and width.
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <returns>A 2D array of Terrain objects representing the generated map.</returns>
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

        // choosing the river's starting row and column
        int row = random.Next(0, 2) == 0 ? 0 : random.Next(0, height - 1);
        int column = row == 0 ? random.Next(0, width - 1) : 0;

        map[row][column] = new Terrain(1);

        // from top to bottom
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
        // from left to right
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