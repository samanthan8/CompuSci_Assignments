using System.Data;
using System.Net.Sockets;
using System.Text.Json.Serialization;
using System.Transactions;
using Utility;

namespace RocketScience
{
    
    public class Driver()
    {
        public static void Level1()
        {
            GradientDescent optimizer = new(learningRate: 2000, 1e-3, maxIterations: 1000000, stepSize: 100, initialGuess: [100000], minimumBounds: [10000], maximumBounds: [1e10]);

            Function function = new();
            double[] result = optimizer.FindMinimum(function.Level1);
            double optimizedFuel = result[0];

            Function final = new();
            final.Level1(result);
            double time = final.Time;
            double position = final.RocketPosition;


            // Use Gradient Descent
            // Output the optimal fuel, time, and end position of rocket
            Console.WriteLine($"Optimized Fuel: {optimizedFuel} kg");
            Console.WriteLine($"Final Time: {time} seconds");
            Console.WriteLine($"Final Position: {position} meters");
        }
        public static void Main(string[] args)
        {
            Level1();
        }
    }
}