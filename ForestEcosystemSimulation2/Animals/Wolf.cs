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
        _health = Random.Next(15, 31);
        _speed = Random.NextDouble() * (1 - 0.5) + 0.5;
        _size = 1;
        _strength = Random.NextDouble() * 0.8;
    }


}