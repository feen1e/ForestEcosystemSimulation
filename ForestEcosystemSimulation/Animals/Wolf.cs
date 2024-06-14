namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a wolf in the forest ecosystem simulation.
/// </summary>
public class Wolf : Carnivore
{
    /*
     * health = [15-30]
     * speed = [0.5-1]
     * size = 1
     * strength= [0-0.8]
     */

    public Wolf()
    {
        MaxHealth = Random.Next(15, 31);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (1 - 0.5) + 0.5;
        Size = 1;
        Strength = Random.NextDouble() * 0.8;
    }

    /// <summary>
    /// Moves the wolf randomly to a valid location on the map, avoiding river tiles (Type 1).
    /// Moves two times when starting from a forest (<see cref="Terrain"/> of type 0).
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The 2D array representing the terrain map.</param>
    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        if (map[Y][X].Type == 0) // if the wolf is in the forest, it moves two times
        {
            base.Move(height, width, map);
        }
        base.Move(height, width, map);
    }

    /// <summary>
    /// Simulates a hunt on a herbivore animal. If the animal is a <see cref="Hare"/> additional strength is added.
    /// </summary>
    /// <param name="herbivore">The herbivore target.</param>
    protected override void Hunt(Herbivore herbivore)
    {
        var str = Strength;
        if (herbivore.GetType() == typeof(Hare)) // hunting hares is easier for wolves so they get extra strength
        {
            Strength += 0.2;
        }
        base.Hunt(herbivore);
        Strength = str;
    }
}