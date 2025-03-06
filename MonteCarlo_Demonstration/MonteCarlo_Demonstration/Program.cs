const double radiusOfCircle = 1;
const double sideOfSquare = 2 * radiusOfCircle;
const double areaOfSquare = sideOfSquare * sideOfSquare;

const long pointsInSquare = 1000;

int pointsInCircle = 0;

var random = new Random();

for (int i = 0; i < pointsInSquare; i++)
{
    double xCoord = random.NextDouble() * 2 - 1;
    double yCoord = random.NextDouble() * 2 - 1;
    
    if (xCoord * xCoord + yCoord*yCoord < radiusOfCircle * radiusOfCircle)
    {
        ++pointsInCircle;
    }
}

Console.WriteLine($"Points in square: {pointsInSquare}");
Console.WriteLine($"Points in circle: {pointsInCircle}");
Console.WriteLine($"Area of circle: {(double)pointsInCircle / pointsInSquare * areaOfSquare}");