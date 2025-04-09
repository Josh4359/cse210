public class Square : Shape
{
    double _side;

    public override double GetArea() => Math.Pow(_side, 2);

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }
}