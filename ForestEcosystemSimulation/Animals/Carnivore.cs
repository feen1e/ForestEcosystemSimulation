using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Abstract base class representing a carnivorous animal in the forest ecosystem simulation.
/// </summary>
public abstract class Carnivore : Animal
{
    /// <summary>
    /// Strength of the carnivore, influencing its hunting success.
    /// </summary>
    public double Strength { get; protected set; }
    
    /// <summary>
    /// Number of successful hunts the carnivore performed
    /// </summary>
    public int SuccessfulHunts { get; private set; } = 0;

    protected Carnivore()
    {
        Diet = 2;
    }

    /// <summary>
    /// Simulates a hunt on a herbivore animal.
    /// </summary>
    /// <param name="herbivore">The herbivore target.</param>
    protected virtual void Hunt(Herbivore herbivore)
    {
        // If the herbivore is a hare and is hidden, the hunt fails
        if (herbivore.GetType() == typeof(Hare))
        {
            var hare = herbivore as Hare;
            if (hare.IsHidden) return;
        }
        
        Console.WriteLine($"{GetType().Name} is hunting a {herbivore.GetType().Name}.");
        bool dodged = false;
        int attack = (int)(Random.Next(1, 51) * Strength);
        
        // Determine if the prey dodged based on speed difference
        if (herbivore.Speed > Speed)
        {
            dodged = Random.Next(1, 6) > (herbivore.Speed - Speed) * 10;
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
    /// Simulates a hunt on an omnivore animal.
    /// </summary>
    /// <param name="omnivore">The omnivore target.</param>
    private void Hunt(Omnivore omnivore)
    {
        Console.WriteLine($"{GetType().Name} is hunting a {omnivore.GetType().Name}.");
        bool dodged = false;
        int attack = (int)(Random.Next(1, 51) * Strength);
        
        // Determine if the prey dodged based on speed difference
        if (omnivore.Speed > Speed)
        {
            dodged = Random.Next(1, 11) > (omnivore.Speed - Speed) * 10;
        }

        if (dodged) return;
        omnivore.Health -= attack;
        if (omnivore.Health <= 0)
        {
            Console.WriteLine($"{GetType().Name} killed {omnivore.GetType().Name}.");
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (omnivore.Size + 1) * 5 + 1) / 10);
            SuccessfulHunts += 1;
        }
        else
        {
            Console.WriteLine($"{omnivore.GetType().Name} didn't die");
        }
    }
    
    /// <summary>
    /// Determines the carnivore's next action based on its priorities and surrounding environment.
    /// </summary>
    /// <param name="priorities">List of actions sorted by priority.</param>
    /// <param name="tileInfos">Information about surrounding tiles.</param>
    /// <param name="map">The simulation map.</param>
    /// <param name="animals">List of animals in the simulation.</param>
    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        List<Animal> animals)
    {
        base.MakeDecision(priorities, tileInfos, map, animals);
        /*
         * 3 - hunt
         */
        if (tileInfos.Any(info => info.Content is 4 or 5))
        {
            priorities.Insert(0, 3);
        }

        bool acted = false;
        foreach (var priority in priorities)
        {
            if (Energy < 0.15 || Hunger > 0.85 || Thirst > 0.85)
            {
                if (priority == 0)
                {
                    Rest();
                    acted = true;
                    break;
                }
                else if (priority == 1)
                {
                    if (tileInfos.Any(info => info.Content == 0))
                    {
                        // food/eat
                        var meat = tileInfos
                            .Where(info => info.Content == 0 && map[info.Y][info.X].Contents is Food { IsPlant: false })
                            .OrderBy(info => Math.Abs(info.X - X) + Math.Abs(info.Y - Y))
                            .ToList();
                        if (meat.Count > 0)
                        {
                            var food = map[meat[0].Y][meat[0].X].Contents as Food;
                            Move(meat[0].X, meat[0].Y);
                            Eat(food);

                            acted = true;    
                            break;
                        }
                    }
                }
                else if (priority == 2)
                {
                    // water/drink
                    if (tileInfos.Any(info => info.Content == 3))
                    {
                        var a = tileInfos.Select(info => info).First(info => info.Content == 3);
                        Move(a.X, a.Y);
                        Drink();
                        acted = true;
                        break;
                    }
                }
            }
            else if (priority == 3)
            {
                // animal/hunt
                if (tileInfos.Any(info => info.Content == 2))
                {
                    var infos = tileInfos.Select(info => info).Where(info => info.Content is 4 or 5).ToList();
                    var possibleTargets = infos
                        .Where(info => animals.Any(animal => animal.X == info.X && animal.Y == info.Y && animal.Size <= Size))
                        .Select(info => animals.First(animal => animal.X == info.X && animal.Y == info.Y))
                        .ToList();

                    if (possibleTargets.Count > 0)
                    {
                        Animal chosenTarget = possibleTargets[Random.Next(possibleTargets.Count)];
                        Move(chosenTarget.X, chosenTarget.Y);
                        if (chosenTarget.GetType() == typeof(Deer) || chosenTarget.GetType() == typeof(Hare))
                        {
                            Hunt((Herbivore)chosenTarget);
                        }
                        else if (chosenTarget.GetType() == typeof(Bear) || chosenTarget.GetType() == typeof(Racoon))
                        {
                            Hunt((Omnivore)chosenTarget);
                        }
                    }
                    acted = true;
                    break;
                }
            }
        }

        if (!acted)
        {
            Move(map.Length, map[0].Length, map);
        }
    }
}