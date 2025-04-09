public class Rectangle : Shape
{
    double _length, _width;

    public override double GetArea() => _length * _width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }
}