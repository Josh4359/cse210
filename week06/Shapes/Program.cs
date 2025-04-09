using System;
using static Utility;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new()
        {
            new Square("blue", 2),
            new Rectangle("green", 5, 3),
            new Circle("red", 4)
        };

        foreach (Shape shape in shapes)
            Print($"Shape: {shape.GetType().Name}; Area: {Math.Round(shape.GetArea(), 2)}; Color: {shape.GetColor()}");
    }
}