namespace ForestEcosystemSimulation.Animals;

public class Hare : Herbivore
{
    /*
     * health = [1-10]
     * speed = [0.5-0.7]
     * size = 0
     * canHide = true
     */

    public Hare()
    {
        MaxHealth = Random.Next(1, 10);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.7 - 0.5) + 0.5;
        Size = 0;
        CanHide = true;
    }
}