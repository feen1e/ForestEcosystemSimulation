using ForestEcosystemSimulation2.TileContents.Food;

namespace ForestEcosystemSimulation2.Animals;

public abstract class Animal
{
    protected static readonly Random Random = new();

    protected int _health;
    protected double _hunger = 0;
    protected double _thirst = 0;
    protected double _energy = 1;
    protected double _speed;
    protected int _size;
    protected int _diet;
    public int _x { get; set; }
    public int _y { get; set; }

    public void Move(int height, int width, Terrain.Terrain[][] map)
    {
        int newX, newY;
        int count = 0;
        do
        {
            count += 1;
            newX = _x + Random.Next(-1, 2);
            newY = _y + Random.Next(-1, 2);
            newX = Math.Max(0, Math.Min(newX, width - 1));
            newY = Math.Max(0, Math.Min(newY, height - 1));
        } while (map[newY][newX]._type == 1 || count < (_speed + _energy) * 10);

        _x = newX;
        _y = newY;
    }

    public void Eat(Food food)
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