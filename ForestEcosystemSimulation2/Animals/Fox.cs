namespace ForestEcosystemSimulation.Animals;

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
        Health = Random.Next(10, 26);
        Speed = Random.NextDouble() * (0.8 - 0.3) + 0.3;
        Size = 0;
        Strength = Random.NextDouble() * 0.6;
    }
}