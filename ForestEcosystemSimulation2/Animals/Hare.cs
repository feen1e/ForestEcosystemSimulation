namespace ForestEcosystemSimulation2.Animals;

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
        _health = Random.Next(1, 10);
        _speed = Random.NextDouble() * (0.7 - 0.5) + 0.5;
        _size = 0;
        _canHide = true;
    }
}