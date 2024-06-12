namespace ForestEcosystemSimulation.Animals;

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
        CanClimb = true;
        CanHunt = false;
        Strength = 0;
    }
}