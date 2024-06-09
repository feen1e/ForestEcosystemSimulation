using ForestEcosystemSimulation2.TileContents;
using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public abstract class Omnivore : Animal
{
    protected bool CanClimb { get; init; }
    protected bool CanHunt { get; init; }
    protected double Strength { get; init; }

    protected Omnivore()
    {
        Diet = 1;
    }

    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        if (!CanClimb)
        {
            base.Move(height, width, map);
        }
        else
        {
            int newX, newY;
            int count = 0;
            do
            {
                count += 1;
                newX = X + Random.Next(-1, 2);
                newY = Y + Random.Next(-1, 2);
                newX = Math.Max(0, Math.Min(newX, width - 1));
                newY = Math.Max(0, Math.Min(newY, height - 1));
            } while (count < (Speed + Energy) * 10);

            X = newX;
            Y = newY;
            UsedEnergy();
        }
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

    protected void Hunt(Carnivore carnivore)
    {
    }

    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        Animal[][] animals)
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
                        Eat(map[info.Y][info.X].Contents as Food);
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
            else if (priority == 3 && CanHunt)
            {
                // animal/hunt
                if (tileInfos.Any(info => info.Content == 2))
                {
                    var infos = tileInfos.Select(info => info).Where(info => info.Content is 4 or 6).ToList();
                    //Move(a.X, a.Y);
                    foreach (var info in infos)
                    {
                        
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