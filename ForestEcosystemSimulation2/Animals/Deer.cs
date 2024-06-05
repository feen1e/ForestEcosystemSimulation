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
        _health = Random.Next(10, 21);
        _speed = Random.NextDouble() * (0.8 - 0.4) + 0.4;
        _size = 1;
        _canHide = false;
    }
}