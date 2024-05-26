namespace ForestEcosystemSimulation.Animals;

public abstract class Omnivore : Animal
{

    protected bool CanClimb;
    protected bool CanHunt;
    protected double Strength;
    
    protected Omnivore()
    {
        Diet = 1;
    }
}