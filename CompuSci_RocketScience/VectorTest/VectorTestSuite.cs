//using System.Numerics;
using Utility;

namespace VectorTest
{
    [TestClass]
    public sealed class VectorTestSuite
    {
        [TestMethod]
        public void AdditionTest()
        {
            //Adding two vectors with 0, negative, and decimal values
            var vec1 = new Vector(0, -7, .15);
            var vec2 = new Vector(1.5, -2.8, 1);
            var sum1 = vec1 + vec2;
            var answer1 = new Vector(1.5, -9.8, 1.15);
            Assert.IsTrue(sum1 == answer1);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            //Subtracting two vectors with 0, negative, and decimal values
            var vec1 = new Vector(0, -7, .15);
            var vec2 = new Vector(1.5, -2.8, 1);
            var diff1 = vec1 - vec2;
            var answer1 = new Vector(-1.5, -4.2, -0.85);
            Assert.IsTrue(diff1 == answer1);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            // Tests positive decimal scalar
            var vec1 = new Vector(0, -7, .15);
            var scalar1 = 3.5;
            var prod1 = scalar1 * vec1;
            var answer1 = new Vector(0, -24.5, 0.525);
            Assert.IsTrue(ToleranceEquals(prod1, answer1));

            // Tests zero scalar
            var scalar2 = 0;
            var prod3 = scalar2 * vec1;
            var answer3 = new Vector(0, 0, 0);
            Assert.IsTrue(ToleranceEquals(prod1, answer1));

            // Tests negative scalar
            var scalar3 = -3;
            var prod4 = vec1 * scalar3;
            var answer4 = new Vector(0, 21, -0.45);
            Assert.IsTrue(ToleranceEquals(prod1, answer1));
        }

        [TestMethod]
        public void DivideTest()
        {
            // Tests positive decimal scalar
            var vec1 = new Vector(0, -7, .15);
            var scalar1 = 0.05;
            var quot1 = vec1 / scalar1;
            var answer1 = new Vector(0, -140, 3);
            Assert.IsTrue(ToleranceEquals(quot1, answer1));

            // Tests negative scalar
            var scalar3 = -2;
            var quot4 = vec1 / scalar3;
            var answer4 = new Vector(0, 3.5, -0.075);
            Assert.IsTrue(ToleranceEquals(quot4, answer4));
        }

        [TestMethod]
        public void MagnitudeTest()
        {
            // Tests a vector with 0, negative, and decimal values
            var vec1 = new Vector(0, -7, .15);
            var mag1 = vec1.Magnitude;
            var answer1 = 7.0016069584;
            Assert.IsTrue(ToleranceEquals(mag1, answer1));

            // Tests a vector with 0 values
            var vec2 = new Vector(0, 0, 0);
            var mag2 = vec2.Magnitude;
            var answer2 = 0;
            Assert.IsTrue(ToleranceEquals(mag2, answer2));
        }

        [TestMethod]
        public void DotTest()
        {
            // Tests two vectors with 0, negative, and decimal values
            var vec1 = new Vector(0, -2, .13);
            var vec2 = new Vector(1.5, -2.8, 1);
            var dot1 = Vector.Dot(vec1, vec2);
            var answer1 = 5.73;
            Assert.IsTrue(ToleranceEquals(dot1, answer1));

            // Tests two vectors with 0 values
            var vec3 = new Vector(0, 0, 0);
            var dot2 = Vector.Dot(vec1, vec3);
            var answer2 = 0;
            Assert.IsTrue(ToleranceEquals(dot2, answer2));
        }

        [TestMethod]
        public void CrossTest()
        {
            // Tests two vectors with 0, negative, and decimal values
            var vec1 = new Vector(0, -2, .13);
            var vec2 = new Vector(1.5, -2.8, 1);
            var dot1 = Vector.Cross(vec1, vec2);
            var answer1 = new Vector(-1.636, 0.195, 3);
            Assert.IsTrue(ToleranceEquals(dot1, answer1));

            // Tests two vectors with 0 values
            var vec3 = new Vector(0, 0, 0);
            var dot2 = Vector.Cross(vec1, vec3);
            var answer2 = new Vector (0, 0, 0);
            Assert.IsTrue(ToleranceEquals(dot2, answer2));
        }

        [TestMethod]
        public void AngleTest()
        {
            // Tests two vectors with 0, negative, and decimal values
            Vector vec1 = new Vector(0, -2, .13);
            Vector vec2 = new Vector(1.5, -2.8, 1);
            double angle1 = Vector.Angle(vec1, vec2);
            double answer1 = 0.538447179209603;

            //Tests zero angle
            double angle2 = Vector.Angle(vec1, vec1);
            double answer2 = 0;
            Assert.IsTrue(ToleranceEquals(angle1, answer1));
        }

        public bool ToleranceEquals(Vector a, Vector b)
        {
            double tolerance = 1e-10;
            return Math.Abs(a.X - b.X) < tolerance &&
                   Math.Abs(a.Y - b.Y) < tolerance &&
                   Math.Abs(a.Z - b.Z) < tolerance;
        }

        public bool ToleranceEquals(double a, double b)
        {
            double tolerance = 1e-6;
            return Math.Abs(a - b) < tolerance;
        }
    }
}
