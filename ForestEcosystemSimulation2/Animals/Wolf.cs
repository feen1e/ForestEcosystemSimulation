namespace ForestEcosystemSimulation2.Animals;

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
        Health = Random.Next(15, 31);
        Speed = Random.NextDouble() * (1 - 0.5) + 0.5;
        Size = 1;
        Strength = Random.NextDouble() * 0.8;
    }


}