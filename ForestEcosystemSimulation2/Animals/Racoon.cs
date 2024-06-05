namespace ForestEcosystemSimulation2.Animals;

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
        _health = Random.Next(5, 16);
        _speed = Random.NextDouble() * (0.6 - 0.2) + 0.2;
        _size = 0;
        _canClimb = true;
        _canHunt = false;
        _strength = 0;
    }
}