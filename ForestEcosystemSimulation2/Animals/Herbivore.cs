namespace ForestEcosystemSimulation2.Animals;

public abstract class Herbivore : Animal
{
    protected bool CanHide;
    protected bool IsHidden = false;

    protected Herbivore()
    {
        Diet = 0;
    }

    protected void Hide()
    {

    }
}