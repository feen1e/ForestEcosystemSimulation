namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a bear in the forest ecosystem simulation.
/// </summary>
public class Bear : Omnivore
{
    /*
     * health = [20-30]
     * speed = [0-0.5]
     * size = 1
     * canClimb= false
     * canHunt  = true
     * strength = [0.5-1]
     */

    /// <summary>
    /// Number of successful hunts the bear performed
    /// </summary>
    public int SuccessfulHunts { get; set; } = 0;
    
    /// <summary>
    /// The strength of the bear, influencing hunting abilities.
    /// </summary>
    private double Strength { get; init; }
    
    public Bear()
    {
        MaxHealth = Random.Next(20, 31);
        Health = MaxHealth;
        Speed = Random.NextDouble() * 0.5;
        Size = 1;
        Strength = Random.NextDouble() * (1 - 0.5) + 0.5;
    }

        /// <summary>
    /// Simulates the omnivore hunting a herbivore.
    /// </summary>
    /// <param name="herbivore">The herbivore target.</param>
    public void Hunt(Herbivore herbivore)
    {
        // If the herbivore is a hare and is hidden, the hunt fails
        if (herbivore.GetType() == typeof(Hare))
        {
            var hare = herbivore as Hare;
            if (hare.IsHidden) return;
        }
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
            Console.WriteLine($"{GetType().Name} killed {herbivore.GetType().Name}.");
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (herbivore.Size + 1) * 5 + 1) / 10);
            SuccessfulHunts += 1;
        }
    }

    /// <summary>
    /// Simulates the omnivore hunting a carnivore.
    /// </summary>
    /// <param name="carnivore">The carnivore target.</param>
    public void Hunt(Carnivore carnivore)
    {
        Console.WriteLine($"{GetType().Name} is hunting a {carnivore.GetType().Name}.");
        bool dodged = false;
        bool countered = false;
        int attack = (int)(Random.Next(1, 51) * Strength);
        if (carnivore.Speed > Speed)
        {
            dodged = Random.Next(1, 11) > (carnivore.Speed - Speed) * 10;
        }
        if (dodged) return;
        if (carnivore.Strength > Strength)
        {
            countered = Random.Next(1, 11) > (carnivore.Strength - Strength) * 10;
        }

        if (!countered)
        {
            carnivore.Health -= attack;
            if (carnivore.Health <= 0)
            {
                Console.WriteLine($"{GetType().Name} killed {carnivore.GetType().Name}.");
                Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (carnivore.Size + 1) * 5 + 1) / 10);
            }
        }
        else
        {
            int counter = (int)(Random.Next(1, 21) * carnivore.Strength);
            if (carnivore.Speed > Speed)
            {
                Health -= counter;
                if (Health <= 0)
                {
                    Console.WriteLine($"{carnivore.GetType().Name} killed {GetType().Name}.");
                    return;
                }
                carnivore.Health -= attack;
                if (carnivore.Health <= 0)
                {
                    Console.WriteLine($"{GetType().Name} killed {carnivore.GetType().Name}.");
                    Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (carnivore.Size + 1) * 5 + 1) / 10);
                }
            }
            else
            {
                carnivore.Health -= attack;
                if (carnivore.Health <= 0)
                {
                    Console.WriteLine($"{GetType().Name} killed {carnivore.GetType().Name}.");
                    Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (carnivore.Size + 1) * 5 + 1) / 10);
                    return;
                }
                Health -= counter;
                if (Health <= 0)
                {
                    Console.WriteLine($"{carnivore.GetType().Name} killed {GetType().Name}.");
                }
            }
        }
    }
}