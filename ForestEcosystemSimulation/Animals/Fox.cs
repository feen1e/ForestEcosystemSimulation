namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a fox in the forest ecosystem simulation.
/// </summary>
public class Fox : Carnivore
{
    /*
     * health = [10-25]
     * speed= [0.3-0.8]
     * size = 0
     * strength= [0-0.6]
     */

    public Fox()
    {
        MaxHealth = Random.Next(10, 26);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.8 - 0.3) + 0.3;
        Size = 0;
        Strength = Random.NextDouble() * 0.6;
    }
    
    /// <summary>
    /// Moves the fox randomly to a valid location on the map, avoiding river tiles (Type 1).
    /// Moves two times when starting from a meadow (<see cref="Terrain"/> of type 2).
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The 2D array representing the terrain map.</param>
    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        if (map[Y][X].Type == 2) // if the fox is in the meadow, it moves two times
        {
            base.Move(height, width, map);
        }
        base.Move(height, width, map);
    }
}