using ForestEcosystemSimulation2.TileContents;
using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public abstract class Herbivore : Animal
{
    protected bool CanHide;
    public bool IsHidden = false;

    protected Herbivore()
    {
        Diet = 0;
    }

    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        Animal[][] animals)
    {
        base.MakeDecision(priorities, tileInfos, map, animals);
        /*
         * Hide - 3
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
            else if (priority == 3 && CanHide)
            {
                // burrow/hide
                if (tileInfos.Any(info => info.Content == 2))
                {
                    var a = tileInfos.Select(info => info).First(info => info.Content == 2);
                    Move(a.X, a.Y);
                    Hide(map[a.Y][a.X].Contents as Burrow);
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

    private void Hide(Burrow burrow)
    {
        if (CanHide && burrow != null && !burrow.IsOccupied)
        {
            IsHidden = true;
            burrow.Occupied();
        }
    }
}