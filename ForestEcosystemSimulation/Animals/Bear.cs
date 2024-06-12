namespace ForestEcosystemSimulation.Animals;

public class Bear : Omnivore
{
    /*
     * health = [20-30]
     * speed = [0-0.5]
     * size = 1
     * canClimb= false
     * canHunt  = true
     * strength = [0.5-1]
     */

    public Bear()
    {
        MaxHealth = Random.Next(20, 31);
        Health = MaxHealth;
        Speed = Random.NextDouble() * 0.5;
        Size = 1;
        CanClimb = false;
        CanHunt = true;
        Strength = Random.NextDouble() * (1 - 0.5) + 0.5;
    }

}