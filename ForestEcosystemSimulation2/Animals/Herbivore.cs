namespace ForestEcosystemSimulation2.Animals;

public abstract class Herbivore : Animal
{
    protected bool _canHide;
    protected bool _isHidden = false;

    protected Herbivore()
    {
        _diet = 0;
    }

    protected void Hide()
    {

    }
}