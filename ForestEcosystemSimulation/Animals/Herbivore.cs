using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Abstract base class representing a herbivorous animal in the forest ecosystem simulation.
/// </summary>
public abstract class Herbivore : Animal
{
    protected Herbivore()
    {
        Diet = 0;
    }

    /// <summary>
    /// Determines the herbivore's next action based on its priorities and surrounding environment.
    /// </summary>
    /// <param name="priorities">List of actions sorted by priority.</param>
    /// <param name="tileInfos">Information about surrounding tiles.</param>
    /// <param name="map">The simulation map.</param>
    /// <param name="animals">List of animals in the simulation.</param>
    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        List<Animal> animals)
    {
        base.MakeDecision(priorities, tileInfos, map, animals);

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
                        var infos = tileInfos.Select(info => info).Where(i => i.Content == 0).ToArray();
                        foreach (var info in infos)
                        {
                            var food = map[info.Y][info.X].Contents as Food;
                            if (food.IsPlant)
                            {
                                Move(info.X, info.Y);
                                Eat(map[info.Y][info.X].Contents as Food);
                                acted = true;
                                break;
                            }
                        } 
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
        }

        if (!acted)
        {
            Move(map.Length, map[0].Length, map);
        }
    }
}