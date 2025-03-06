// See https://aka.ms/new-console-template for more information
using CompuSci_ProjectileMotion;
using Utility;

class ProjectileMotion
{
    //using var file = File.CreateText("output.csv"); >>>> creates an automatically closing csv file
    public static void Main(String[] args)
    {
        Level1();
        //Level2();
        //Level3();
    }
    public static void Level1()
    {
        World world = new();
        world.GravitationalFieldStrength = 9.8;
        double DeltaTime = 0.01;

        double mass = 3;

        Vector pos = new(0, 0, 0);

        double speed = 4;
        double direction = double.Pi / 4; // 45 degrees in radians
        Vector vel = new(speed * Math.Cos(direction), 0, speed * Math.Sin(direction));

        Projectile projectile = new Projectile(mass, dragCoefficient:0, pos, vel);
        world.AddProjectile(projectile);

        Console.WriteLine("Time(s)\tX(m)\tY(m)\tZ(m)\tSpeed(m/s)\tAcceleration(m/s^2)");
        while (projectile.Position.Z >= 0)
        {
            world.UpdateWorld(DeltaTime);
            speed = projectile.Velocity.Magnitude;
            double acceleration = projectile.Acceleration.Magnitude;
            Console.WriteLine($"{world.CurrentTime}\t{projectile.Position.X}\t{projectile.Position.Y}\t{projectile.Position.Z}\t{speed}\t{acceleration}");
        }
    }

    public static void Level2()
    {
        World world = new();
        world.GravitationalFieldStrength = 9.8;
        double DeltaTime = 0.01;

        double mass = 3;
        
        Vector pos = new(0, 0, 0);

        double speed = 4;
        double direction = double.Pi / 4; // 45 degrees in radians
        Vector vel = new(speed * Math.Cos(direction), 0, speed * Math.Sin(direction));

        double dragCoefficient = 0.6;

        Projectile projectile = new Projectile(mass, dragCoefficient, pos, vel);
        world.AddProjectile(projectile);

        Console.WriteLine("Time(s)\tX(m)\tY(m)\tZ(m)\tSpeed(m/s)\tAcceleration(m/s^2)");
        while (projectile.Position.Z >= 0)
        {
            world.UpdateWorld(DeltaTime);
            speed = projectile.Velocity.Magnitude;
            double acceleration = projectile.Acceleration.Magnitude;
            Console.WriteLine($"{world.CurrentTime}\t{projectile.Position.X}\t{projectile.Position.Y}\t{projectile.Position.Z}\t{speed}\t{acceleration}");
        }
    }

    private static void Level3()
    {
        World world = new();
        world.GravitationalFieldStrength = 9.8;
        double DeltaTime = 0.01;

        double mass = 3;

        Vector pos = new(-1, 1, -1);
        Vector vel = new(5, -1, -3);

        Projectile projectile = new Projectile(mass, 0.6, pos, vel);
        world.AddProjectile(projectile);

        Vector anchorPoint = new Vector(0, 0, 0);
        Spring spring = new Spring(-9, 2, anchorPoint, projectile);
        world.AddSpring(spring);

        Console.WriteLine("Time(s)\tX(m)\tY(m)\tZ(m)\tSpeed(m/s)\tAcceleration(m/s^2)");
        while (world.CurrentTime <= 10)
        {
            world.UpdateWorld(DeltaTime);
            double speed = projectile.Velocity.Magnitude;
            double acceleration = projectile.Acceleration.Magnitude;
            Console.WriteLine($"{world.CurrentTime}\t{projectile.Position.X}\t{projectile.Position.Y}\t{projectile.Position.Z}\t{speed}\t{acceleration}");
        }
    }
}
