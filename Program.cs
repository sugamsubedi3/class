using System;

// Define a class to represent a circle
class Circle
{
    // Properties to store radius and center coordinates
    public double Radius { get; private set; }
    public double XCenter { get; private set; }
    public double YCenter { get; private set; }

    // Constructor to initialize circle properties
    public Circle(double radius, double xCenter, double yCenter)
    {
        Radius = radius;
        XCenter = xCenter;
        YCenter = yCenter;
    }

    // Method to calculate the surface area of the circle
    public double CalculateSurface()
    {
        return Math.PI * Radius * Radius;
    }

    // Method to calculate the perimeter of the circle
    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    // Method to check if a given point lies inside the circle
    public bool IsPointInside(double x, double y)
    {
        double distance = Math.Sqrt(Math.Pow(x - XCenter, 2) + Math.Pow(y - YCenter, 2));
        return distance <= Radius;
    }
}

class Program
{
    // Method to create an array of circles based on user input
    static Circle[] CreateCircles(int numberOfCircles)
    {
        Circle[] circles = new Circle[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            Console.WriteLine($"Enter the radius for circle {i + 1}:");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the x-coordinate for circle {i + 1}:");
            double xCenter = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the y-coordinate for circle {i + 1}:");
            double yCenter = double.Parse(Console.ReadLine());

            // Create a new circle object with user-provided parameters
            circles[i] = new Circle(radius, xCenter, yCenter);
        }
        return circles;
    }

    // Method to print information about a circle (surface area and perimeter)
    static void PrintCircleInformation(Circle circle)
    {
        Console.WriteLine($"Surface of the circle: {circle.CalculateSurface()}");
        Console.WriteLine($"Perimeter of the circle: {circle.CalculatePerimeter()}");
    }

    // Method to check if a point is inside each circle and print the result
    static void CheckPointInCircles(double x, double y, Circle[] circles)
    {
        foreach (var circle in circles)
        {
            if (circle.IsPointInside(x, y))
                Console.WriteLine($"Point ({x}, {y}) is inside the circle with radius {circle.Radius}");
            else
                Console.WriteLine($"Point ({x}, {y}) is outside the circle with radius {circle.Radius}");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("How many circles do you want to create?");
        int numberOfCircles = int.Parse(Console.ReadLine());

        // Create an array of circles based on user input
        Circle[] circles = CreateCircles(numberOfCircles);

        // Print information about each circle (surface area and perimeter)
        foreach (var circle in circles)
        {
            Console.WriteLine("\nCircle Information:");
            PrintCircleInformation(circle);
        }

        // Prompt the user to enter a point to check its position relative to the circles
        Console.WriteLine("\nEnter a point to check its position relative to the circles:");
        Console.Write("X-coordinate: ");
        double xPoint = double.Parse(Console.ReadLine());
        Console.Write("Y-coordinate: ");
        double yPoint = double.Parse(Console.ReadLine());

        // Check if the point is inside each circle and print the result
        CheckPointInCircles(xPoint, yPoint, circles);
    }
}
