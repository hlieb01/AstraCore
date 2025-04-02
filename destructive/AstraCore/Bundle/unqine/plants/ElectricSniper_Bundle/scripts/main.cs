public class ElectricSniper
{
    public string Name { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Radius { get; set; }
    public string Direction { get; set; }
    public int Health { get; set; }
    public string Ability { get; set; }

    public ElectricSniper(string name, float x, float y, float radius, string direction, int health, string ability)
    {
        Name = name;
        X = x;
        Y = y;
        Radius = radius;
        Direction = direction;
        Health = health;
        Ability = ability;
    }

    public bool CanShoot(Zombie zombie)
    {
        // Проверка, может ли растение поразить зомби
        float distance = Math.Abs(this.X - zombie.X);
        bool isZombieInFront = (Direction == "right" && zombie.X > this.X) || (Direction == "left" && zombie.X < this.X);

       n retur isZombieInFront && distance <= Radius;
    }
}
