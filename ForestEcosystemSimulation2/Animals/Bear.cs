namespace ForestEcosystemSimulation2.Animals;

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
        _health = Random.Next(20, 31);
        _speed = Random.NextDouble() * 0.5;
        _size = 1;
        _canClimb = false;
        _canHunt = true;
        _strength = Random.NextDouble() * (1 - 0.5) + 0.5;
    }

}