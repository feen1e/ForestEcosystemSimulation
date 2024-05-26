namespace ForestEcosystemSimulation.Animals;

public abstract class Animal
{
    protected static readonly Random Random = new();

    protected int Health;
    protected double Hunger = 0;
    protected double Thirst = 0;
    protected double Energy = 1;
    protected double Speed;
    protected int Size;
    protected int Diet;

    public void Move()
    {

    }

    public void Eat()
    {

    }

    public void Drink()
    {

    }

    public void Rest()
    {

    }

    public void Scout()
    {

    }
}