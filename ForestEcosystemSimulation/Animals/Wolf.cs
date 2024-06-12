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


}