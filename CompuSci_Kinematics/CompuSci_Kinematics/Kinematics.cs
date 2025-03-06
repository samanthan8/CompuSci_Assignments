// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Linq.Expressions;

class Kinematics
{
    static void Main(String[] args)
    {
        Level1();
        Level2();
        Level3();
        Challenge();
    }
    static void Level1()
    {
        double delta_time = 0.1;
        double sim_time = 100;
        double vel = 4;
        double pos = 0;

        Console.WriteLine("Time(s)\tPosition(m)\tVelocity(m/s)\tAcceleration(m/s^2)");
        for (double time = 0; time <= sim_time; time += delta_time)
        {
            EulerMethod(delta_time, time, ref vel, ref pos, acceleration: 0);
        }
    }
    static void Level2()
    {
        double delta_time = 0.1;
        double sim_time = 100;
        double vel = 4;
        double pos = 0;
        double acceleration = -9.8;

        Console.WriteLine("Time(s)\tPosition(m)\tVelocity(m/s)\tAcceleration(m/s^2)");
        for (double time = 0; time <= sim_time; time += delta_time)
        {
            EulerMethod(delta_time, time, ref vel, ref pos, acceleration);
        }
    }

    static void Level3()
    {
        double delta_time = 0.1;
        double sim_time = 100;
        double vel = 4;
        double pos = 0;
        double grav_const = -9.8;
        double mass = 3;
        double drag_coeff = 0.6;
        double drag_force = drag_coeff*Math.Pow(vel,2)*-Math.Sign(vel);
        double net_force = mass * grav_const + drag_force;
        double acceleration = net_force / mass;

        Console.WriteLine("Time(s)\tPosition(m)\tVelocity(m/s)\tAcceleration(m/s^2)");
        for (double time = 0; time <= sim_time; time += delta_time)
        {
            EulerMethod(delta_time, time, ref vel, ref pos, acceleration);
            drag_force = drag_coeff * Math.Pow(vel, 2) * -Math.Sign(vel);
            net_force = mass * grav_const + drag_force;
            acceleration = net_force / mass;
        }
    }

    static void Challenge()
    {
        double delta_time = 0.1;
        double sim_time = 100;
        double vel = 5;
        double pos = -1;
        double spring_length = 2;
        double spring_const = 9;
        double grav_const = -9.8;
        double mass = 3;
        double drag_coeff = 0.6;
        double drag_force = drag_coeff * Math.Pow(vel, 2) * -Math.Sign(vel);
        double restoring_force = -spring_const * (pos + spring_length);
        double net_force = mass * grav_const + drag_force + restoring_force;
        double acceleration = net_force / mass;

        Console.WriteLine("Time(s)\tPosition(m)\tVelocity(m/s)\tAcceleration(m/s^2)");
        for (double time = 0; time <= sim_time; time += delta_time)
        {
            EulerMethod(delta_time, time, ref vel, ref pos, acceleration);
            drag_force = drag_coeff * Math.Pow(vel, 2) * -Math.Sign(vel);
            restoring_force = -spring_const * (pos + spring_length);
            net_force = mass * grav_const + drag_force + restoring_force;
            acceleration = net_force / mass;
        }
    }

    private static void EulerMethod(double delta_time, double time, ref double vel, ref double pos, double acceleration)
    {
        Console.WriteLine($"{time}\t{pos}\t{vel}\t{acceleration}");
        vel += acceleration * delta_time;
        pos += vel * delta_time;
    }
}
