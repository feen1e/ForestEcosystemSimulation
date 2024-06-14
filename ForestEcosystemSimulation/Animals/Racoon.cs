namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a racoon in the forest ecosystem simulation.
/// </summary>
public class Racoon : Omnivore
{
    /*
     * health = [5-15]
     * speed = [0.2-0.6]
     * size = 0
     * canClimb = true
     * canHunt = false
     * strength = 0
     */

    public Racoon()
    {
        MaxHealth = Random.Next(5, 16);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.6 - 0.2) + 0.2;
        Size = 0;
        Strength = 0;
    }
    
    /// <summary>
    /// Simulates the omnivore climbing to a new position.
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    private void Climb(int height, int width, Terrain.Terrain[][] map)
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
        } while (count < (Speed + Energy) * 10);
        
        X = newX;
        Y = newY;
        Console.WriteLine(map[Y][X].Contents?.TileType == 1
            ? $"{GetType().ToString().Split('.').Last()} climbed to [{X}, {Y}]."
            : $"{GetType().ToString().Split('.').Last()} moved to [{X}, {Y}].");
        UsedEnergy();
    }
    
    /// <summary>
    /// Overrides the base Move method to allow climbing by calling <see cref="Climb"/>.
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The simulation map.</param>
    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        Climb(height, width, map); // climb method also handles moving 
    }
}