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
}