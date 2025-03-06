using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace CompuSci_ProjectileMotion
{
    public class Projectile(double mass, double dragCoefficient, Vector position, Vector velocity)
    {
        public double Mass { get; init; } = mass;
        public bool HasSpring { get; set; } = false;
        public double DragCoefficient { get; init; } = dragCoefficient;
        public Vector Position { get; set; } = position;
        public Vector Velocity { get; set; } = velocity;
        public Vector Acceleration { get; set; } = new Vector(0, 0, 0);
        /// <summary>
        /// Updates the kinematic quantities of the projectile based on Euler's method using the force and delta time
        /// </summary>
        /// <param name="netForce"></param>
        /// <param name="deltaTime"></param>
        public void UpdateMotion(Vector netForce, double deltaTime)
        {
            Acceleration = netForce / Mass;
            Velocity += Acceleration * deltaTime;   
            Position += Velocity * deltaTime;
        }

    }
}
