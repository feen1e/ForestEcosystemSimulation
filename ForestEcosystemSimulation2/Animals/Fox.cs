namespace ForestEcosystemSimulation2.Animals;

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
        _health = Random.Next(10, 26);
        _speed = Random.NextDouble() * (0.8 - 0.3) + 0.3;
        _size = 0;
        _strength = Random.NextDouble() * 0.6;
    }
}