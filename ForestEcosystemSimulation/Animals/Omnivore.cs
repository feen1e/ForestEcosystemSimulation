using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Abstract base class representing an omnivorous animal in the forest ecosystem simulation.
/// </summary>
public abstract class Omnivore : Animal
{
    protected Omnivore()
    {
        Diet = 1;
    }

    /// <summary>
    /// Determines the omnivore's next action based on its priorities and surrounding environment.
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
         * Hunt - 3
         */
        if (tileInfos.Any(info => info.Content is 4 or 6))
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
                        var info = tileInfos.Select(info => info).First(i => i.Content == 0);
                        var food = map[info.Y][info.X].Contents as Food;
                        Move(info.X, info.Y);
                        Eat(food);
                        acted = true;
                        break;
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
            else if (priority == 3 && this is Bear)
            {
                var bear = this as Bear;
                // animal/hunt
                if (tileInfos.Any(info => info.Content == 2))
                {
                    var infos = tileInfos.Select(info => info).Where(info => info.Content is 4 or 6).ToList();
                    var possibleTargets = infos
                        .Where(info => animals.Any(animal => animal.X == info.X && animal.Y == info.Y && animal.Size <= Size))
                        .Select(info => animals.First(animal => animal.X == info.X && animal.Y == info.Y))
                        .ToList();

                    if (possibleTargets.Count > 0)
                    {
                        Animal chosenTarget = possibleTargets[Random.Next(possibleTargets.Count)];
                        Move(chosenTarget.X, chosenTarget.Y);

                        switch (chosenTarget)
                        {
                            case Herbivore herbivore:
                                bear.Hunt(herbivore);
                                break;
                            case Carnivore carnivore:
                                bear.Hunt(carnivore);
                                break;
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