using System.Data;
using System.Text.Json.Serialization;
using System.Transactions;
using Utility;

namespace RocketScience
{
    /// <summary>
    /// This class represents a rocket and its properties, including payload, fuel, position, velocity, and acceleration.
    /// </summary>
    public class Rocket(double fuel, double burnRate, double maxThrustForce)
    {
        public const double EarthRadius = 6371e3;
        public const double GravitationalConstant = 6.67430e-11;
        public const double EarthMass = 5.97219e24;

        public double Payload { get; set; } = 126371;
        public double Fuel { get; set; } = fuel;
        public double Time { get; private set; } = 0;
        public Utility.Vector Gravity { get; set; } = new Vector(0, 0, -9.81);
        public double BurnRate { get; set; } = burnRate; // in kg/s
        public double MaxThrustForce { get; set; } = maxThrustForce; // in Newtons
        public double Distance { get; set; } = EarthRadius;
        public Utility.Vector Position { get; set; } = new Vector(0, 0, 0);
        public Utility.Vector MaxHeight { get; set; } = new Vector(0, 0, 0); // Maximum height reached by the rocket
        public Utility.Vector Velocity { get; set; } = new Vector(0, 0, 0);
        public Utility.Vector Acceleration { get; set; } = new Vector(0, 0, 0);
        public Utility.Vector Thrust { get; set; } = new Vector(0, 0, 0);
        public double Mass => Payload + Fuel;

        /// <summary>
        /// Updates the rocket's properties based on the elapsed time.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateRocket(double deltaTime)
        {
            if (Fuel > 0)
            {
                Fuel -= BurnRate * deltaTime;
            }
            else
            {
                Fuel = 0;
            }
            Gravity = CalculateGravity();
            Thrust = CalculateThrust();
            Vector netForce = Gravity + Thrust;
            UpdateMotion(netForce, deltaTime);

            double max = Math.Max(Position.Z, MaxHeight.Z);
            MaxHeight = new Vector(0, 0, max); // Update maximum height reached by the rocket

            Time += deltaTime;
        }

        /// <summary>
        /// Updates the rocket's position and velocity based on the net force and elapsed time (Euler method).
        /// </summary>
        /// <param name="netForce"></param>
        /// <param name="DeltaTime"></param>
        public void UpdateMotion(Vector netForce, double DeltaTime)
        {
            Acceleration = netForce / Mass;
            Velocity += Acceleration * DeltaTime;
            Position += Velocity * DeltaTime;

            if (Position.Z < 0)
            {
                Acceleration.Z = 0; // Stop acceleration if below ground level
                Velocity.Z = 0; // Stop velocity if below ground level
                Position.Z = 0; // Prevent going below ground level
            }
            //Console.WriteLine($"Time: {Time}, Position: {Position.Z}, Velocity: {Velocity.Z}, Acceleration: {Acceleration.Z}");
        }

        /// <summary>
        /// Calculates the gravitational force acting on the rocket.
        /// </summary>
        /// <returns></returns>
        public Vector CalculateGravity()
        {
            Distance = Position.Z + EarthRadius;
            return (GravitationalConstant * EarthMass * Mass / (Distance * Distance)) * Gravity.UnitVector;
        }


        /// <summary>
        /// Calculates the thrust force based on the remaining fuel and burn rate.
        /// </summary>
        /// <returns></returns>
        public Vector CalculateThrust()
        {
            if (Fuel > BurnRate)
            {
                Thrust = new Vector(0, 0, MaxThrustForce);
            }
            else if (Fuel > 0)
            {
                Thrust = new Vector(0, 0, MaxThrustForce * (Fuel / BurnRate));
            }
            else
            {
                Thrust = new Vector(0, 0, 0);
            }
            return Thrust;
        }
    }
}