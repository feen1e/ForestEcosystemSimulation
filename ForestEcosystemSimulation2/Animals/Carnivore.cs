namespace ForestEcosystemSimulation2.Animals;

public class Carnivore : Animal
{
    protected double Strength { get; init; }

    protected Carnivore()
    {
        Diet = 2;
    }

    protected void Hunt(Herbivore herbivore)
    {
        if (herbivore.IsHidden) return;
        bool dodged = false;
        int attack = (int)(Random.Next(1, 51) * Strength);
        if (herbivore.Speed > Speed)
        {
            dodged = Random.Next(1, 11) > (herbivore.Speed - Speed) * 10;
        }

        if (dodged) return;
        herbivore.Health -= attack;
        if (herbivore.Health <= 0)
        {
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (herbivore.Size + 1) * 5 + 1) / 10);
        }
    }

    protected void Hunt(Omnivore omnivore)
    {
        bool dodged = false;
        int attack = (int)(Random.Next(1, 51) * Strength);
        if (omnivore.Speed > Speed)
        {
            dodged = Random.Next(1, 11) > (omnivore.Speed - Speed) * 10;
        }

        if (dodged) return;
        omnivore.Health -= attack;
        if (omnivore.Health <= 0)
        {
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (omnivore.Size + 1) * 5 + 1) / 10);
        }
    }
}