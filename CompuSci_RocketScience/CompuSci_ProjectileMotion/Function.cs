using System.Data;
using System.Text.Json.Serialization;
using System.Transactions;
using Utility;

namespace RocketScience
{
    
    public class Function()
    {
        public double RocketPosition = 0;
        public double Time = 0;

        public double Level1(double[] Fuel)
        {

            RocketPosition = 0;
            Time = 0;

            // Rocket parameters
            double fuel = Fuel[0];
            Rocket rocket = new(fuel, burnRate: 240, maxThrustForce: 1.2e7);

            double penaltyFactor = 2; // penalty for exceeding fuel limit
            double posGoal = 3.5e7; // geostationary orbit
            double deltaTime = 0.01; // seconds

            while (true)
            {
                RocketPosition = rocket.Position.Z;
                Time = rocket.Time;
                rocket.UpdateRocket(deltaTime);
                if (rocket.Fuel <= 0)
                {
                    break;
                }
                if (rocket.Position.Z > posGoal)
                {
                    break;
                }
                if (rocket.Position.Z == 0)
                {
                    break;
                }
            }

            return Time;
        }
    }
}