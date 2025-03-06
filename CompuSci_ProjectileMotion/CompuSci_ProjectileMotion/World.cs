using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace CompuSci_ProjectileMotion
{
    public class World
    {
        public List<Projectile> Projectiles { get;} = [];
        public List<Spring> Springs { get; } = [];
        public double CurrentTime { get; private set; } = 0;

        public void AddProjectile(Projectile projectile)
        {
            Projectiles.Add(projectile);
        }
        public void AddSpring(Spring spring)
        {
            Springs.Add(spring);
        }
        public double GravitationalFieldStrength { get; set; }
        public void UpdateWorld(double DeltaTime)
        {
            foreach (var projectile in Projectiles) //updates forces for each projectile
            {
                Vector netForce = CalculateGraviationalForce(projectile) + CalculateAirResistanceForce(projectile);
                foreach (var spring in Springs) //check if any springs are attached to projectile and add spring force if yes
                {
                    if (spring.Projectile1 == projectile)
                    {
                        netForce += CalculateSpringForce(spring, projectile);
                    }
                    if (spring.Projectile2 == projectile)
                    {
                        netForce += -CalculateSpringForce(spring, projectile);
                    }
                }

                projectile.UpdateMotion(netForce, DeltaTime);
            }
            CurrentTime += DeltaTime;
        }
        public Vector CalculateGraviationalForce(Projectile projectile)
        {
            return new Vector(0, 0, -GravitationalFieldStrength * projectile.Mass);
        }

        public Vector CalculateAirResistanceForce(Projectile projectile)
        {
            return -projectile.Velocity.UnitVector * Math.Pow(projectile.Velocity.Magnitude, 2) * projectile.DragCoefficient;
        }

        public Vector CalculateSpringForce(Spring spring, Projectile p)
        {
            return spring.getSpringForce(p);
        }
    }
}
