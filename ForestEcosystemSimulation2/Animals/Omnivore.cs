namespace ForestEcosystemSimulation2.Animals;

public abstract class Omnivore : Animal
{

    protected bool _canClimb;
    protected bool _canHunt;
    protected double _strength;

    protected Omnivore()
    {
        _diet = 1;
    }
}