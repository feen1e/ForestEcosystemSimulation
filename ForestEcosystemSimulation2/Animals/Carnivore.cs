using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public class Carnivore : Animal
{
    public double Strength { get; init; }

    protected Carnivore()
    {
        Diet = 2;
    }

    protected void Hunt(Herbivore herbivore)
    {
        if (herbivore.IsHidden) return;
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} is hunting a {herbivore.GetType().ToString().Split('.').Last()}.");
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
            Console.WriteLine($"{GetType().ToString().Split('.').Last()} killed {herbivore.GetType().ToString().Split('.').Last()}.");
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (herbivore.Size + 1) * 5 + 1) / 10);
        }
    }

    protected void Hunt(Omnivore omnivore)
    {
        Console.WriteLine($"{GetType().ToString().Split('.').Last()} is hunting a {omnivore.GetType().ToString().Split('.').Last()}.");
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
            Console.WriteLine($"{GetType().ToString().Split('.').Last()} killed {omnivore.GetType().ToString().Split('.').Last()}.");
            Hunger = Math.Max(0, Hunger - (double)Random.Next(2, (omnivore.Size + 1) * 5 + 1) / 10);
        }
        else
        {
            Console.WriteLine($"{omnivore.GetType().ToString().Split('.').Last()} didn't die");
        }
    }
    
    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        List<Animal> animals)
    {
        base.MakeDecision(priorities, tileInfos, map, animals);
        /*
         * Hunt - 3
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
                            .Where(info => info.Content == 0 && map[info.Y][info.X].Contents is Food food && !food.IsPlant)
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
                    //Console.WriteLine("Hunt begins");
                    var infos = tileInfos.Select(info => info).Where(info => info.Content is 4 or 5).ToList();
                    //Move(a.X, a.Y);
                    
                    var possibleTargets = infos
                        .Where(info => animals.Any(animal => animal.X == info.X && animal.Y == info.Y && animal.Size <= Size))
                        .Select(info => animals.First(animal => animal.X == info.X && animal.Y == info.Y))
                        .ToList();
                        /*.Select(info => animals[info.Y][info.X])
                        .Where(animal => animal != null && animal.Size <= Size)
                        .ToList();*/

                    if (possibleTargets.Count > 0)
                    {
                        //Console.WriteLine("Target found");
                        Animal chosenTarget = possibleTargets[Random.Next(possibleTargets.Count)];
                        Move(chosenTarget.X, chosenTarget.Y);
                        Console.WriteLine(chosenTarget + " " + chosenTarget.GetType());
                        if (chosenTarget.GetType() == typeof(Deer) || chosenTarget.GetType() == typeof(Hare))
                        {
                            Hunt((Herbivore)chosenTarget);
                            //Console.WriteLine("Hunting herbivore");
                        }
                        else if (chosenTarget.GetType() == typeof(Bear) || chosenTarget.GetType() == typeof(Racoon))
                        {
                            //Console.WriteLine("Hunting omnivore");
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