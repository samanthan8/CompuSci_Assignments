using System;
using Utility;

namespace CompuSci_ProjectileMotion
{
    public class Spring
    {
        public double SpringConstant { get; init; }
        public double SpringLength { get; init; }
        public Vector? AnchorPoint { get; private set; }
        public Projectile Projectile1 { get; init; }
        public Projectile? Projectile2 { get; init; }
        public double CurrentLength { get; private set; }

        // Constructor for a spring anchored at one end
        public Spring(double springConstant, double springLength, Vector anchorPoint, Projectile projectile)
        {
            SpringConstant = springConstant;
            SpringLength = springLength;
            AnchorPoint = anchorPoint;
            Projectile1 = projectile;
            Projectile2 = null;
            projectile.HasSpring = true;

            UpdateSpring();
        }

        // Constructor for a spring connecting two projectiles
        public Spring(double springConstant, double springLength, Projectile projectile1, Projectile projectile2)
        {
            SpringConstant = springConstant;
            SpringLength = springLength;
            Projectile1 = projectile1;
            Projectile2 = projectile2;
            AnchorPoint = null;
            projectile1.HasSpring = true;
            projectile2.HasSpring = true;

            UpdateSpring();
        }

        public void UpdateSpring()
        {
            if (Projectile2 != null)
            {
                // Calculate the length between two projectiles
                CurrentLength = (Projectile1.Position - Projectile2.Position).Magnitude;
            }
            else
            {
                // Calculate the length between the projectile and the anchor point
                CurrentLength = (Projectile1.Position - AnchorPoint).Magnitude;
            }
        }

        public Vector getSpringForce(Projectile p)
        {
            UpdateSpring();
            double displacement = SpringLength - CurrentLength;
            Vector direction;
            if (p == Projectile1 || p == Projectile2)
            {
                if (Projectile2 == null)
                {
                    // Calculate the direction from the anchor point to the projectile
                    direction = (AnchorPoint - p.Position).UnitVector;
                }
                else
                {
                    direction = (Projectile2.Position - Projectile1.Position).UnitVector;
                }

                return -SpringConstant * displacement * direction;
            }

            else
            {
                return new Vector(0, 0, 0);
            }

            
        }
    }
}