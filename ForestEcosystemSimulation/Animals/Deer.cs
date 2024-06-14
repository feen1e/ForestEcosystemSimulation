namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a deer in the forest ecosystem simulation.
/// </summary>
public class Deer : Herbivore
{
    /*
     * health = [10-20]
     * speed = [0.4-0.8]
     * size = 1
     * canHide = false
     */

    public Deer()
    {
        MaxHealth = Random.Next(10, 21);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.8 - 0.4) + 0.4;
        Size = 1;
    }

    /// <summary>
    /// Moves the deer randomly to a valid location on the map, avoiding river tiles (Type 1).
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The 2D array representing the terrain map.</param>
    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        int newX, newY;
        int count = 0;
        do
        {
            count += 1;
            newX = X + Random.Next(-2, 3);
            newY = Y + Random.Next(-2, 3);
            newX = Math.Max(0, Math.Min(newX, width - 1));
            newY = Math.Max(0, Math.Min(newY, height - 1));
        } while (map[newY][newX].Type == 1 && count < (Speed + Energy) * 10);

        X = newX;
        Y = newY;
        Console.WriteLine($"{GetType().Name} moved to [{X}, {Y}].");
    }
}