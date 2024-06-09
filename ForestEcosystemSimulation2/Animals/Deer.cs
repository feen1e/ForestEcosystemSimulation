namespace ForestEcosystemSimulation2.Animals;

public class Deer : Herbivore
{
    /*
     * health = [10-20]
     * speed = [0.4-0.8]
     * size = 1
     * canHide = false
     */

    public Deer()
    {
        MaxHealth = Random.Next(10, 21);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.8 - 0.4) + 0.4;
        Size = 1;
        CanHide = false;
    }
}