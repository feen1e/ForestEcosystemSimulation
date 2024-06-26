using ForestEcosystemSimulation.TileContents;
using ForestEcosystemSimulation.TileContents.Food;

namespace ForestEcosystemSimulation.Animals;

/// <summary>
/// Represents a hare in the forest ecosystem simulation.
/// </summary>
public class Hare : Herbivore
{
    /*
     * health = [1-10]
     * speed = [0.5-0.7]
     * size = 0
     * canHide = true
     */
    
    /// <summary>
    /// Indicates whether this herbivore is currently hidden in a burrow.
    /// </summary>
    public bool IsHidden { get; private set; } = false;

    public Hare()
    {
        MaxHealth = Random.Next(1, 10);
        Health = MaxHealth;
        Speed = Random.NextDouble() * (0.7 - 0.5) + 0.5;
        Size = 0;
    }

    /// <summary>
    /// Determines the hare's next action based on its priorities and surrounding environment.
    /// </summary>
    /// <param name="priorities">List of actions sorted by priority.</param>
    /// <param name="tileInfos">Information about surrounding tiles.</param>
    /// <param name="map">The simulation map.</param>
    /// <param name="animals">List of animals in the simulation.</param>
    protected override void MakeDecision(List<int> priorities, List<TileInfo> tileInfos, Terrain.Terrain[][] map,
        List<Animal> animals)
    {
        priorities.Clear();
        Dictionary<int, double> values = new Dictionary<int, double>
        {
            { 0, 1 - Energy },
            { 1, Hunger },
            { 2, Thirst }
        };
        priorities.AddRange(values.Keys);
        priorities.Sort((a, b) => values[b].CompareTo(values[a]));
        /*
         * 0 - rest
         * 1 - eat
         * 2 - drink
         * 3 - hide
         */

        // Prioritize hiding if omnivores or carnivores are nearby
        if (tileInfos.Any(info => info.Content is 5 or 6))
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
            else if (priority == 3)
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

    /// <summary>
    /// Simulates the herbivore hiding in a burrow.
    /// </summary>
    /// <param name="burrow">The burrow to hide in.</param>
    private void Hide(Burrow burrow)
    {
        if (burrow is { IsOccupied: false })
        {
            Console.WriteLine($"{GetType().Name} hides.");
            IsHidden = true;
            burrow.Occupied();
        }
    }
    
    /// <summary>
    /// Overrides the base Move method to handle leaving a burrow if hidden.
    /// </summary>
    /// <param name="height">The height of the map.</param>
    /// <param name="width">The width of the map.</param>
    /// <param name="map">The simulation map.</param>
    protected override void Move(int height, int width, Terrain.Terrain[][] map)
    {
        var tileContents = map[Y][X].Contents;
        bool isBurrow = false;
        if (tileContents != null)
        {
            isBurrow = tileContents.TileType == 2;
        }

        if (isBurrow && IsHidden)
        {
            var burrow = tileContents as Burrow;
            burrow.Occupied();
            IsHidden = false;
        }
        base.Move(height, width, map);
    }

}