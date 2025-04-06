using System.Data;
using System.Text.Json.Serialization;
using System.Transactions;
using Utility;

namespace RocketScience
{
    /// <summary>
    /// This class is responsible for optimizing the rocket's trajectory and performance.
    /// </summary>
    public class GradientDescent(double learningRate, double tolerance, int maxIterations, double stepSize, double[] initialGuess, double[] minimumBounds, double[] maximumBounds)
    {
        private double learningRate = learningRate;
        private double tolerance = tolerance;
        private int maxIterations = maxIterations;
        public double stepSize = stepSize;
        double[] initialGuess = initialGuess;
        double[] minimumBounds = minimumBounds;
        double[] maximumBounds = maximumBounds;

        public double[] FindMinimum(Func<double[], double> function)
        {
            double[] guess = initialGuess; // Initial guess
            for (int i = 0; i < maxIterations; i++)
            {
                double[] gradient = ComputeGradient(function, guess);
                for (int j = 0; j < guess.Length; j++)
                {
                    guess[j] -= learningRate * gradient[j];
                }

                guess = ClampGuess(guess);

                if (IsConverged(gradient))
                {
                    break;
                }
            }
            return guess;
        }

        private double[] ComputeGradient(Func<double[], double> function, double[] guess)
        {
            double[] gradient = new double[guess.Length];
            double h = stepSize; // Small step for numerical gradient
            for (int i = 0; i < gradient.Length; i++)
            {
                double[] guessStepped = (double[])guess.Clone();
                guessStepped[i] += h;
                double funcStepped = function(guessStepped);
                double func = function(guess);


                gradient[i] = (funcStepped - func) / h;

                Console.WriteLine($"Gradient[{i}]: {gradient[i]} & Guess[{i}]: {guess[i]}"); // Debugging output
            }
            return gradient;
        }

        private bool IsConverged(double[] gradient)
        {
            foreach (double g in gradient)
            {
                if (Math.Abs(g) > tolerance)
                {
                    return false;
                }
            }
            return true;
        }

        private double[] ClampGuess(double[] guess)
        {
            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = Math.Max(minimumBounds[i], Math.Min(maximumBounds[i], guess[i]));
            }
            return guess;
        }
    }
}